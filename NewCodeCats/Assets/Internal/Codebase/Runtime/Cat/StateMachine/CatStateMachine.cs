using System;
using System.Collections;
using System.Collections.Generic;
using Internal.Codebase.Infrastructure.Services.CameraService;
using Internal.Codebase.Infrastructure.Services.CoroutineRunner;
using Internal.Codebase.Infrastructure.Services.NumberAbbreviator;
using Internal.Codebase.Runtime.Cat.StateMachine.States;
using UnityEngine;

namespace Internal.Codebase.Runtime.Cat.StateMachine
{
    public class CatStateMachine : MonoBehaviour
    {
        private Dictionary<Type, EntityState> states;
        private EntityState activeEntityState;

        public UnityEngine.Camera Camera { get; private set; }

        public ICoroutineRunner CoroutineRunner { get; private set; }

        [SerializeField] private IdleState idleState;
        [SerializeField] private RunState runState;
        [SerializeField] private DragState dragState;
        [SerializeField] private ClickState clickState;
        [SerializeField] private MergeState mergeState;

        [SerializeField] private CircleCollider2D circleCollider2D;

        [field: SerializeField] public Markers.Cat Cat { get; private set; }

        private Coroutine coroutineBeforeRun;
        private Coroutine coroutine;

        private Vector3 positionOnMouseDown;
        private Vector3 positionOnMouseUp;
        private ICameraService cameraService;
        private bool canMerge;
        public INumberAbbreviatorService NumberAbbreviatorService { get; private set; }
        public GameObject CollisionCat { get; private set; }

        public void Constructor(ICoroutineRunner coroutineRunner, ICameraService cameraService,
            INumberAbbreviatorService numberAbbreviatorService)
        {
            NumberAbbreviatorService = numberAbbreviatorService;
            if (this.CoroutineRunner != null && this.cameraService != null)
                return;
            this.cameraService = cameraService;
            CoroutineRunner = coroutineRunner;

            Camera = this.cameraService.GetCamera();
        }

        private void OnEnable()
        {
            ChangeToRunState();
            circleCollider2D.enabled = false;
        }

        private void Start()
        {
            activeEntityState.Enter(this);
            activeEntityState.StartState(this);
        }

        private void Update()
        {
            activeEntityState.UpdateState(this);
        }

        private void FixedUpdate()
        {
            activeEntityState.FixedUpdateState(this);
        }

        private void OnMouseDown()
        {
            ChangeToDragState();
            positionOnMouseDown = transform.position;
            positionOnMouseDown.z = 0;
        }

        private void OnMouseDrag()
        {
            activeEntityState.OnMouseDragState(this);
        }

        private void OnMouseUp()
        {
            canMerge = true;
            
            positionOnMouseUp = transform.position;
            positionOnMouseUp.z = 0;

            if (positionOnMouseUp == positionOnMouseDown)
                ChangeToClickState();

            if (coroutineBeforeRun != null)
                StopCoroutine(coroutineBeforeRun);
            
            if(coroutine != null)
                StopCoroutine(coroutine);

            coroutineBeforeRun = StartCoroutine(AfterMouseUpAndBeforeRunTimer());
            coroutine = StartCoroutine(AfterMouseUpTimer());

            circleCollider2D.enabled = true;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            activeEntityState.OnCollisionEnter2D(other);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            activeEntityState.OnTriggerEnter2D(other);
            if(canMerge && other.TryGetComponent(out Markers.Cat cat))
            {
                if (cat.Type == Cat.Type)
                {
                    canMerge = false;
                    CollisionCat = other.gameObject;
                    ChangeToMergeState();
                }
            }
        }

        public TState ChangeState<TState>() where TState : EntityState
        {
            activeEntityState?.Exit(this);

            TState state = GetState<TState>();
            activeEntityState = state;

            return state;
        }

        private TState GetState<TState>() where TState : EntityState
            => states[typeof(TState)] as TState;

        public void ChangeToRunState()
        {
            activeEntityState?.Exit(this);
            activeEntityState = runState;
            activeEntityState.Enter(this);
        }

        public void ChangeToIdleState()
        {
            activeEntityState?.Exit(this);
            activeEntityState = idleState;
            activeEntityState.Enter(this);
        }

        public void ChangeToDragState()
        {
            activeEntityState?.Exit(this);
            activeEntityState = dragState;
            activeEntityState.Enter(this);
        }

        public void ChangeToClickState()
        {
            activeEntityState?.Exit(this);
            activeEntityState = clickState;
            activeEntityState.Enter(this);
        }

        public void ChangeToMergeState()
        {
            activeEntityState?.Exit(this);
            activeEntityState = mergeState;
            activeEntityState.Enter(this);
        }

        private IEnumerator AfterMouseUpAndBeforeRunTimer()
        {
            yield return new WaitForSeconds(1.5f);
            ChangeToRunState();
        }

        private IEnumerator AfterMouseUpTimer()
        {
            yield return new WaitForSeconds(0.5f);
            circleCollider2D.enabled = false;
            canMerge = false;
        }

        /*public void ChangeToRunState() => ChangeState<RunState>().Enter(this);
        public void ChangeToIdleState() => ChangeState<IdleState>().Enter(this);
        public void ChangeToDragState() => ChangeState<DragState>().Enter(this);*/
    }
}