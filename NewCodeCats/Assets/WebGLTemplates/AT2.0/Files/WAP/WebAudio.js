const audioPath = "./StreamingAssets/Audio/";
const sourceDictionary = {};

function PlayAudio(sourceID, clipPath, loop, volume, mute){
    if(sourceDictionary[sourceID] !== undefined){
        sourceDictionary[sourceID].stop();
    }

    clipPath = audioPath + clipPath;

    var source = new Howl({
        src: [clipPath],
        html5: false,
        loop: Boolean(loop),
        autoplay: true,
        volume: volume,
        mute: Boolean(mute),
    })

    //source.on("end", endCallback)
    sourceDictionary[sourceID] = source;
}

function SetAudioSourceLoop(sourceID, value) {
    const source = sourceDictionary[sourceID];

    if(source !== undefined){
        source.loop(Boolean(value));
    }
}

function SetAudioSourceVolume(sourceID, value) {
    const source = sourceDictionary[sourceID];

    if(source !== undefined){
        source.volume(value);
        console.log("set volume");
    }
}

function SetAudioSourceMute(sourceID, value) {
    const source = sourceDictionary[sourceID];
    
    if(source !== undefined){
        source.mute(Boolean(value));
    }
}

function StopAudioSource(sourceID) {
    const source = sourceDictionary[sourceID];
    
    if(source !== undefined){
        source.stop();
        console.log("stop");
    }
}

function AudioMute(value){
    Howler.mute(Boolean(value));
}

function DeleteAudioSource(sourceID){
    StopAudioSource(sourceID);

    sourceDictionary[sourceID] = undefined;
}

function SetAudioSourcePitch(sourceID, value){
    const source = sourceDictionary[sourceID];
    
    if(source !== undefined){
        source.rate(value);
        console.log("rate");
    }
}

function SetGlobalVolume(value){
    Howler.volume(value);
}

function GetAudioSourceTime(sourceID){
    const source = sourceDictionary[sourceID];
    
    if(source !== undefined){
        source.rate(value);
        return source.seek();
    }

    return 0;
}

function IsPlayingAudioSource(sourceID){
    const source = sourceDictionary[sourceID];
    
    if(source !== undefined){
        source.rate(value);
        return source.playing();
    }

    return false;
}