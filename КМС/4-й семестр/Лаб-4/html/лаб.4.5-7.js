(function (cjs, an) {

var p; // shortcut to reference prototypes
var lib={};var ss={};var img={};
lib.ssMetadata = [
		{name:"лаб.4.5_7_atlas_1", frames: [[1384,670,112,112],[1384,784,112,112],[1565,670,387,747],[1565,1419,433,527],[814,554,568,590],[0,1532,659,513],[1490,0,478,668],[814,1146,749,435],[1384,898,112,112],[661,1583,840,357],[1384,1012,112,112],[0,1108,812,422],[731,0,757,552],[0,619,784,487],[0,0,729,617]]},
		{name:"лаб.4.5_7_atlas_2", frames: [[0,0,112,112],[0,114,112,112],[114,0,112,112]]}
];


(lib.AnMovieClip = function(){
	this.currentSoundStreamInMovieclip;
	this.actionFrames = [];
	this.soundStreamDuration = new Map();
	this.streamSoundSymbolsList = [];

	this.gotoAndPlayForStreamSoundSync = function(positionOrLabel){
		cjs.MovieClip.prototype.gotoAndPlay.call(this,positionOrLabel);
	}
	this.gotoAndPlay = function(positionOrLabel){
		this.clearAllSoundStreams();
		this.startStreamSoundsForTargetedFrame(positionOrLabel);
		cjs.MovieClip.prototype.gotoAndPlay.call(this,positionOrLabel);
	}
	this.play = function(){
		this.clearAllSoundStreams();
		this.startStreamSoundsForTargetedFrame(this.currentFrame);
		cjs.MovieClip.prototype.play.call(this);
	}
	this.gotoAndStop = function(positionOrLabel){
		cjs.MovieClip.prototype.gotoAndStop.call(this,positionOrLabel);
		this.clearAllSoundStreams();
	}
	this.stop = function(){
		cjs.MovieClip.prototype.stop.call(this);
		this.clearAllSoundStreams();
	}
	this.startStreamSoundsForTargetedFrame = function(targetFrame){
		for(var index=0; index<this.streamSoundSymbolsList.length; index++){
			if(index <= targetFrame && this.streamSoundSymbolsList[index] != undefined){
				for(var i=0; i<this.streamSoundSymbolsList[index].length; i++){
					var sound = this.streamSoundSymbolsList[index][i];
					if(sound.endFrame > targetFrame){
						var targetPosition = Math.abs((((targetFrame - sound.startFrame)/lib.properties.fps) * 1000));
						var instance = playSound(sound.id);
						var remainingLoop = 0;
						if(sound.offset){
							targetPosition = targetPosition + sound.offset;
						}
						else if(sound.loop > 1){
							var loop = targetPosition /instance.duration;
							remainingLoop = Math.floor(sound.loop - loop);
							if(targetPosition == 0){ remainingLoop -= 1; }
							targetPosition = targetPosition % instance.duration;
						}
						instance.loop = remainingLoop;
						instance.position = Math.round(targetPosition);
						this.InsertIntoSoundStreamData(instance, sound.startFrame, sound.endFrame, sound.loop , sound.offset);
					}
				}
			}
		}
	}
	this.InsertIntoSoundStreamData = function(soundInstance, startIndex, endIndex, loopValue, offsetValue){ 
 		this.soundStreamDuration.set({instance:soundInstance}, {start: startIndex, end:endIndex, loop:loopValue, offset:offsetValue});
	}
	this.clearAllSoundStreams = function(){
		var keys = this.soundStreamDuration.keys();
		for(var i = 0;i<this.soundStreamDuration.size; i++){
			var key = keys.next().value;
			key.instance.stop();
		}
 		this.soundStreamDuration.clear();
		this.currentSoundStreamInMovieclip = undefined;
	}
	this.stopSoundStreams = function(currentFrame){
		if(this.soundStreamDuration.size > 0){
			var keys = this.soundStreamDuration.keys();
			for(var i = 0; i< this.soundStreamDuration.size ; i++){
				var key = keys.next().value; 
				var value = this.soundStreamDuration.get(key);
				if((value.end) == currentFrame){
					key.instance.stop();
					if(this.currentSoundStreamInMovieclip == key) { this.currentSoundStreamInMovieclip = undefined; }
					this.soundStreamDuration.delete(key);
				}
			}
		}
	}

	this.computeCurrentSoundStreamInstance = function(currentFrame){
		if(this.currentSoundStreamInMovieclip == undefined){
			if(this.soundStreamDuration.size > 0){
				var keys = this.soundStreamDuration.keys();
				var maxDuration = 0;
				for(var i=0;i<this.soundStreamDuration.size;i++){
					var key = keys.next().value;
					var value = this.soundStreamDuration.get(key);
					if(value.end > maxDuration){
						maxDuration = value.end;
						this.currentSoundStreamInMovieclip = key;
					}
				}
			}
		}
	}
	this.getDesiredFrame = function(currentFrame, calculatedDesiredFrame){
		for(var frameIndex in this.actionFrames){
			if((frameIndex > currentFrame) && (frameIndex < calculatedDesiredFrame)){
				return frameIndex;
			}
		}
		return calculatedDesiredFrame;
	}

	this.syncStreamSounds = function(){
		this.stopSoundStreams(this.currentFrame);
		this.computeCurrentSoundStreamInstance(this.currentFrame);
		if(this.currentSoundStreamInMovieclip != undefined){
			var soundInstance = this.currentSoundStreamInMovieclip.instance;
			if(soundInstance.position != 0){
				var soundValue = this.soundStreamDuration.get(this.currentSoundStreamInMovieclip);
				var soundPosition = (soundValue.offset?(soundInstance.position - soundValue.offset): soundInstance.position);
				var calculatedDesiredFrame = (soundValue.start)+((soundPosition/1000) * lib.properties.fps);
				if(soundValue.loop > 1){
					calculatedDesiredFrame +=(((((soundValue.loop - soundInstance.loop -1)*soundInstance.duration)) / 1000) * lib.properties.fps);
				}
				calculatedDesiredFrame = Math.floor(calculatedDesiredFrame);
				var deltaFrame = calculatedDesiredFrame - this.currentFrame;
				if(deltaFrame >= 2){
					this.gotoAndPlayForStreamSoundSync(this.getDesiredFrame(this.currentFrame,calculatedDesiredFrame));
				}
			}
		}
	}
}).prototype = p = new cjs.MovieClip();
// symbols:



(lib.CachedBmp_68 = function() {
	this.initialize(ss["лаб.4.5_7_atlas_1"]);
	this.gotoAndStop(0);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_66 = function() {
	this.initialize(ss["лаб.4.5_7_atlas_1"]);
	this.gotoAndStop(1);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_64 = function() {
	this.initialize(ss["лаб.4.5_7_atlas_1"]);
	this.gotoAndStop(2);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_69 = function() {
	this.initialize(ss["лаб.4.5_7_atlas_1"]);
	this.gotoAndStop(3);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_62 = function() {
	this.initialize(ss["лаб.4.5_7_atlas_1"]);
	this.gotoAndStop(4);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_61 = function() {
	this.initialize(ss["лаб.4.5_7_atlas_1"]);
	this.gotoAndStop(5);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_63 = function() {
	this.initialize(ss["лаб.4.5_7_atlas_1"]);
	this.gotoAndStop(6);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_60 = function() {
	this.initialize(ss["лаб.4.5_7_atlas_1"]);
	this.gotoAndStop(7);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_54 = function() {
	this.initialize(ss["лаб.4.5_7_atlas_1"]);
	this.gotoAndStop(8);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_59 = function() {
	this.initialize(ss["лаб.4.5_7_atlas_1"]);
	this.gotoAndStop(9);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_52 = function() {
	this.initialize(ss["лаб.4.5_7_atlas_1"]);
	this.gotoAndStop(10);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_50 = function() {
	this.initialize(ss["лаб.4.5_7_atlas_2"]);
	this.gotoAndStop(0);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_49 = function() {
	this.initialize(ss["лаб.4.5_7_atlas_2"]);
	this.gotoAndStop(1);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_48 = function() {
	this.initialize(ss["лаб.4.5_7_atlas_2"]);
	this.gotoAndStop(2);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_58 = function() {
	this.initialize(ss["лаб.4.5_7_atlas_1"]);
	this.gotoAndStop(11);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_56 = function() {
	this.initialize(ss["лаб.4.5_7_atlas_1"]);
	this.gotoAndStop(12);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_57 = function() {
	this.initialize(ss["лаб.4.5_7_atlas_1"]);
	this.gotoAndStop(13);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_55 = function() {
	this.initialize(ss["лаб.4.5_7_atlas_1"]);
	this.gotoAndStop(14);
}).prototype = p = new cjs.Sprite();



(lib.теложука = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.CachedBmp_69();
	this.instance.setTransform(-17.85,-118.45,0.5,0.5);

	this.timeline.addTween(cjs.Tween.get(this.instance).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-17.8,-118.4,216.5,263.5);


(lib.Stop = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.CachedBmp_66();
	this.instance.setTransform(98,-47.5,0.5,0.5);

	this.instance_1 = new lib.CachedBmp_68();
	this.instance_1.setTransform(98,-47.5,0.5,0.5);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance}]}).to({state:[{t:this.instance}]},1).to({state:[{t:this.instance_1}]},1).to({state:[{t:this.instance_1}]},1).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(98,-47.5,56,56);


(lib.Символ1 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.CachedBmp_55();
	this.instance.setTransform(-112.45,-125.05,0.5,0.5);

	this.instance_1 = new lib.CachedBmp_56();
	this.instance_1.setTransform(-126.25,-139.95,0.5,0.5);

	this.instance_2 = new lib.CachedBmp_57();
	this.instance_2.setTransform(-140.1,-154.8,0.5,0.5);

	this.instance_3 = new lib.CachedBmp_58();
	this.instance_3.setTransform(-153.9,-169.7,0.5,0.5);

	this.instance_4 = new lib.CachedBmp_59();
	this.instance_4.setTransform(-167.75,-184.6,0.5,0.5);

	this.instance_5 = new lib.CachedBmp_60();
	this.instance_5.setTransform(-122.5,-152.9,0.5,0.5);

	this.instance_6 = new lib.CachedBmp_61();
	this.instance_6.setTransform(-77.25,-121.2,0.5,0.5);

	this.instance_7 = new lib.CachedBmp_62();
	this.instance_7.setTransform(-31.95,-89.5,0.5,0.5);

	this.instance_8 = new lib.CachedBmp_63();
	this.instance_8.setTransform(13.3,-57.8,0.5,0.5);

	this.instance_9 = new lib.CachedBmp_64();
	this.instance_9.setTransform(58.55,-26.55,0.5,0.5);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance}]}).to({state:[{t:this.instance_1}]},1).to({state:[{t:this.instance_2}]},1).to({state:[{t:this.instance_3}]},1).to({state:[{t:this.instance_4}]},1).to({state:[{t:this.instance_5}]},1).to({state:[{t:this.instance_6}]},1).to({state:[{t:this.instance_7}]},1).to({state:[{t:this.instance_8}]},1).to({state:[{t:this.instance_9}]},1).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-167.7,-184.6,420,531.6);


(lib.Start = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.CachedBmp_52();
	this.instance.setTransform(118.5,-27.45,0.5,0.5);

	this.instance_1 = new lib.CachedBmp_54();
	this.instance_1.setTransform(118.5,-27.45,0.5,0.5);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance}]}).to({state:[{t:this.instance}]},1).to({state:[{t:this.instance_1}]},1).to({state:[{t:this.instance_1}]},1).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(118.5,-27.4,56,56);


(lib.Back = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.CachedBmp_48();
	this.instance.setTransform(75,-0.5,0.5,0.5);

	this.instance_1 = new lib.CachedBmp_49();
	this.instance_1.setTransform(74.9,-0.5,0.5,0.5);

	this.instance_2 = new lib.CachedBmp_50();
	this.instance_2.setTransform(75,-0.5,0.5,0.5);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance}]}).to({state:[{t:this.instance}]},1).to({state:[{t:this.instance_1}]},1).to({state:[{t:this.instance_2}]},1).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(74.9,-0.5,56.099999999999994,56);


(lib.Фрагментролика = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_2
	this.instance = new lib.Символ1("synched",5);
	this.instance.setTransform(138.75,116.4,0.3763,0.2629,0,29.9957,-150.0024,41.6,81.1);

	this.instance_1 = new lib.Символ1("synched",4);
	this.instance_1.setTransform(-137.1,116.4,0.3763,0.2629,-29.9957,0,0,41.7,81);

	this.instance_2 = new lib.Символ1("synched",0);
	this.instance_2.setTransform(-99.35,-70.75,0.2357,0.1401,29.9995,0,0,41.9,81.3);

	this.instance_3 = new lib.Символ1("synched",3);
	this.instance_3.setTransform(159.65,20,0.3764,0.2629,0,0,180,41.7,81);

	this.instance_4 = new lib.Символ1("synched",1);
	this.instance_4.setTransform(109.05,-68.95,0.2357,0.1401,0,-29.9995,150.0012,41.9,81.3);

	this.instance_5 = new lib.Символ1("synched",2);
	this.instance_5.setTransform(-158.3,25,0.3764,0.2629,0,0,0,41.7,81);

	this.instance_6 = new lib.теложука("synched",0);
	this.instance_6.setTransform(0.7,0.95,1,1,-29.9992,0,0,90.5,13.2);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_6},{t:this.instance_5},{t:this.instance_4},{t:this.instance_3},{t:this.instance_2},{t:this.instance_1},{t:this.instance}]}).wait(60));

	// Слой_1
	this.instance_7 = new lib.Символ1("synched",5);
	this.instance_7.setTransform(138,115.4,0.3763,0.2629,0,29.9957,-150.0024,41.6,81.1);

	this.instance_8 = new lib.Символ1("synched",4);
	this.instance_8.setTransform(-137.85,115.4,0.3763,0.2629,-29.9957,0,0,41.7,81);

	this.instance_9 = new lib.Символ1("synched",0);
	this.instance_9.setTransform(-100.1,-71.75,0.2357,0.1401,29.9995,0,0,41.9,81.3);

	this.instance_10 = new lib.Символ1("synched",3);
	this.instance_10.setTransform(158.9,19,0.3764,0.2629,0,0,180,41.7,81);

	this.instance_11 = new lib.Символ1("synched",1);
	this.instance_11.setTransform(108.3,-69.95,0.2357,0.1401,0,-29.9995,150.0012,41.9,81.3);

	this.instance_12 = new lib.Символ1("synched",2);
	this.instance_12.setTransform(-159.05,24,0.3764,0.2629,0,0,0,41.7,81);

	this.instance_13 = new lib.теложука("synched",0);
	this.instance_13.setTransform(-0.05,-0.05,1,1,-29.9992,0,0,90.5,13.2);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_13},{t:this.instance_12},{t:this.instance_11},{t:this.instance_10},{t:this.instance_9},{t:this.instance_8},{t:this.instance_7}]}).to({state:[]},10).wait(50));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-241,-168.1,482.9,341.79999999999995);


// stage content:
(lib.лаб457 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	this.actionFrames = [0];
	// timeline functions:
	this.frame_0 = function() {
		this.clearAllSoundStreams();
		 
		this.stop();
		this.StartButton.addEventListener("click",f1.bind(this))
		function f1(args){this.play();} 
		this.StopButton.addEventListener("click",f2.bind(this))
		function f2(args){this.stop();} 
		this.BackButton.addEventListener("click",f3.bind(this))
		function f3(args){this.gotoAndStop(0);}
		playSound("жужание");
		this.stop();
		this.StartButton.addEventListener("click",f1.bind(this))
		function f1(args){this.play();} 
		this.StopButton.addEventListener("click",f2.bind(this))
		function f2(args){this.stop();} 
		this.BackButton.addEventListener("click",f3.bind(this))
		function f3(args){this.gotoAndStop(0);}
	}

	// actions tween:
	this.timeline.addTween(cjs.Tween.get(this).call(this.frame_0).wait(60));

	// Слой_18
	this.StopButton = new lib.Stop();
	this.StopButton.name = "StopButton";
	this.StopButton.setTransform(932.65,685.35);
	new cjs.ButtonHelper(this.StopButton, 0, 1, 2, false, new lib.Stop(), 3);

	this.StartButton = new lib.Start();
	this.StartButton.name = "StartButton";
	this.StartButton.setTransform(987.45,665.3);
	new cjs.ButtonHelper(this.StartButton, 0, 1, 2, false, new lib.Start(), 3);

	this.BackButton = new lib.Back();
	this.BackButton.name = "BackButton";
	this.BackButton.setTransform(881.95,638.35);
	new cjs.ButtonHelper(this.BackButton, 0, 1, 2, false, new lib.Back(), 3);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.BackButton},{t:this.StartButton},{t:this.StopButton}]}).wait(60));

	// Слой_14
	this.instance = new lib.Фрагментролика();
	this.instance.setTransform(1289.7,27.05,0.2293,0.2544,-93.2976,0,0,0.2,24.1);

	this.timeline.addTween(cjs.Tween.get(this.instance).to({rotation:-3.2976,guide:{path:[1289.8,27.1,1282.8,27.1,1275.8,27.1,1274.8,27.6,1273.8,33.1,1266.3,33.1,1258.8,33.1,1258.8,34.6,1258.8,36.1,1252.8,45.1,1246.8,54.1,1246.8,57.1,1246.8,60.1,1217.2,94.1,1187.7,128.1,1174.7,128.1,1161.7,128.1,1160.7,126.5,1154.7,126.1,1153,124.5,1148.7,119.1,1139.2,119.1,1129.7,119.1,1109.7,127.6,1089.7,136.1,1027.1,156.1,964.6,176.1,946.1,184.1,927.6,192.1,835,192.1,742.5,192.1,742.5,190.1,742.5,188.1,735.5,188.1,728.5,188.1,603.9,173.6,479.4,159.1,461.9,153.6,444.4,148.1,415.4,130.1,386.4,112.1,380.4,102.7,374.4,93.2,374.4,48.2,374.4,3.1], orient:'fixed'}},59).wait(1));

	// Слой_4
	this.instance_1 = new lib.Фрагментролика();
	this.instance_1.setTransform(930.15,-13.75,0.1794,0.2388,-135,0,0,0.8,24.3);

	this.timeline.addTween(cjs.Tween.get(this.instance_1).to({regX:0.6,regY:24.4,scaleX:0.1793,rotation:-132.2052,guide:{path:[930.2,-13.7,920.2,1.3,910.2,16.3,905.1,18.7,905.2,22.6,902.7,22.6,900.2,22.6,900.2,26.4,900.2,30.1,849.5,90.7,798.9,151.3,791.4,163.2,783.9,175,775.1,184.4,766.4,193.8,745.1,213.2,723.9,232.5,717,240,710.2,247.5,707.1,254.4,702.7,253.8,683.9,265.1,665.1,276.3,665.1,280.7,665.1,285,660.8,287.7,656.5,290.4], orient:'fixed'}},26).wait(1).to({regX:0.4,regY:24.1,scaleY:0.2337,rotation:0,skewX:-115.3406,skewY:-132.6576,x:654.35,y:290.7},0).wait(1).to({scaleY:0.2317,skewX:-108.7228,skewY:-132.8345,x:653.5,y:290.75},0).wait(1).to({scaleY:0.2301,skewX:-103.1714,skewY:-132.9829,x:652.85,y:290.85},0).wait(1).to({scaleY:0.2266,skewX:-91.4403,skewY:-133.2965,x:651.4,y:290.95},0).wait(1).to({scaleY:0.2114,skewX:-40.76,skewY:-134.6512,x:645.3,y:291.5},0).wait(1).to({regX:0.5,regY:24.7,scaleY:0.1862,skewX:43.1042,skewY:-136.893,x:635.1,y:292.55},0).to({regX:0.2,regY:24.6,scaleY:0.2387,rotation:-147.1693,skewX:0,skewY:0,x:635.15,y:292.6},5).to({regX:0.6,regY:24.2,scaleX:0.1794,scaleY:0.2388,rotation:-165.0011,x:242.6,y:711.4},22).wait(1));

	// Слой_13
	this.instance_2 = new lib.Фрагментролика();
	this.instance_2.setTransform(318.2,-8,0.1164,0.1484,-119.9999,0,0,0.7,24.1);

	this.timeline.addTween(cjs.Tween.get(this.instance_2).to({regX:0.5,regY:23.6,rotation:-75.0033,guide:{path:[318.2,-7.9,305.2,-1.9,292.2,4.1,283.7,10.1,275.2,16.1,258.7,31.6,242.2,47.1,236.2,83.7,230.2,120.2,226.2,130.2,222.1,140.1,222.1,146.6,222.1,153.1,218.6,157.6,215.1,162.1,215.1,167.1,215.1,172.1,209.1,184.1,203.1,196.1,202.4,197.4,203.1,202.1,202.6,203.5,197.1,208.1,192.1,213.6,187.1,219.1,179.6,224.6,172.1,230.1,150.2,239.6,128.2,249.1,76.2,253.6,24.1,258.1,23.1,256.6,16.1,253.1,8.6,253.1,1.1,253.1], orient:'fixed'}},59).wait(1));

	// Слой_11
	this.instance_3 = new lib.Фрагментролика();
	this.instance_3.setTransform(1315.35,474.7,0.2293,0.252,-45,0,0,0.5,24.2);

	this.timeline.addTween(cjs.Tween.get(this.instance_3).to({regX:0.7,regY:24.5,scaleX:0.2292,rotation:15.0007,guide:{path:[1315.4,474.8,1306.6,462,1297.8,449.3,1288.8,441.8,1279.8,434.3,1266.3,417.4,1252.8,400.6,1231.2,375.9,1209.7,351.2,1209.7,349.7,1209.7,348.2,1198.7,337.2,1187.7,326.2,1119.7,244.7,1051.7,163.2,1051.7,160.2,1051.7,157.2,1037.6,119.2,1023.6,81.2,1026.6,55.7,1029.6,30.2,1029.6,28.2,1029.6,26.2,1033.6,12.7,1037.6,-0.8], orient:'fixed'}},59).wait(1));

	// Слой_2
	this.instance_4 = new lib.Фрагментролика("synched",0);
	this.instance_4.setTransform(-172.95,358.1,0.3863,0.4675,44.9987,0,0,0.5,24.3);

	this.timeline.addTween(cjs.Tween.get(this.instance_4).to({regY:24.2,rotation:89.9981,guide:{path:[-172.9,358.1,-151.9,340.1,-130.9,322.1,-126.1,321.1,-124,320.6,23.1,337.3,170.1,354.1,189.1,360.1,208.1,366.1,211.1,366.1,214.1,366.1,243.9,378.2,275.8,381.4,312.3,385.1,346.4,369.7,355.1,365.7,363.1,362.1,396.6,350.1,430.1,338.1,430.1,335.1,430.1,332.1,435.6,332.1,441.1,332.1,446.6,328.1,452.1,324.1,458.1,324.1,464.1,324.1,469.1,321.1,474.1,318.1,512.1,318.1,550.1,318.1,553.6,320.7,556.1,320.2,563.1,320.2,570.1,320.2,589.6,329.1,609.1,338.1,619.1,338.1,629.1,338.1,634.6,343.1,640,348.1,643.5,348.1,647,348.1,653,351.6,654,352.1,656,352.1,658,352.1,693.6,365.3,737,373,771.1,379.1,807.9,376.3,828,374.8,847,368.1,859.5,365.1,872,362.1,907,342.6,941.9,323.1,943.9,323.1,945.9,323.1,948.9,318.1,951.9,313.1,958.4,313.1,964.9,313.1,964.9,307.1,965.2,306.1,978.1,293.6,990.9,281.1,999.9,276.1,1008.9,271.1,1068.9,277.6,1128.9,284.1,1152.9,291.6,1176.9,299.1,1308.9,299.1,1440.9,299.1], orient:'fixed'},startPosition:59},59,cjs.Ease.none).wait(1));

	// Слой_9
	this.instance_5 = new lib.Фрагментролика();
	this.instance_5.setTransform(201.15,717.1,0.2392,0.2728,0,0,0,0.4,24.2);

	this.timeline.addTween(cjs.Tween.get(this.instance_5).to({regY:24,rotation:-74.9998,guide:{path:[201.2,717.2,201.2,690.8,201.2,664.4,212.2,626,223.2,587.6,223.2,561.9,223.2,536.3,216.2,535.6,215.2,534.8,211.7,528,208.2,521.3,206.2,521.3,204.2,521.3,204.2,517.5,204.2,513.7,188.2,493.4,172.2,473.1,155.1,455,138.1,436.9,124.6,425.6,111.1,414.3,87.5,371.9,39.1,373.3,20,373.8,0.1,373.6,-6.4,370.5,-7.9,370.5,-11.4,367.5,-13.9,367.5], orient:'fixed'}},59).wait(1));

	// Слой_3
	this.instance_6 = new lib.Фрагментролика();
	this.instance_6.setTransform(548,718.9,0.312,0.3143,0,0,0,0.3,24);

	this.timeline.addTween(cjs.Tween.get(this.instance_6).to({rotation:90,guide:{path:[548.1,718.8,548.1,703.4,548.1,687.9,554.4,686.7,555.1,684.9,555.1,675.4,555.1,665.9,576.6,636.4,598.1,606.9,620.6,584.9,643.1,562.9,664.5,549.9,686,536.9,694.5,532.9,703,528.9,707,528.9,711,528.9,834.5,471.4,958,413.9,999,413.9,1040,413.9,1041.2,408.7,1043,407.9,1047,407.4,1049,405.9,1180.5,402.4,1312,398.9], orient:'fixed'}},59).wait(1));

	this._renderFirstFrame();

}).prototype = p = new lib.AnMovieClip();
p.nominalBounds = new cjs.Rectangle(370.9,301.6,1159.5,463);
// library properties:
lib.properties = {
	id: '150C87E02727DB4B8B9596BCEBF54E47',
	width: 1280,
	height: 720,
	fps: 30,
	color: "#FFFFFF",
	opacity: 1.00,
	manifest: [
		{src:"images/лаб.4.5_7_atlas_1.png?1677382540306", id:"лаб.4.5_7_atlas_1"},
		{src:"images/лаб.4.5_7_atlas_2.png?1677382540306", id:"лаб.4.5_7_atlas_2"},
		{src:"sounds/жужание_.mp3?1677382540331", id:"жужание"}
	],
	preloads: []
};



// bootstrap callback support:

(lib.Stage = function(canvas) {
	createjs.Stage.call(this, canvas);
}).prototype = p = new createjs.Stage();

p.setAutoPlay = function(autoPlay) {
	this.tickEnabled = autoPlay;
}
p.play = function() { this.tickEnabled = true; this.getChildAt(0).gotoAndPlay(this.getTimelinePosition()) }
p.stop = function(ms) { if(ms) this.seek(ms); this.tickEnabled = false; }
p.seek = function(ms) { this.tickEnabled = true; this.getChildAt(0).gotoAndStop(lib.properties.fps * ms / 1000); }
p.getDuration = function() { return this.getChildAt(0).totalFrames / lib.properties.fps * 1000; }

p.getTimelinePosition = function() { return this.getChildAt(0).currentFrame / lib.properties.fps * 1000; }

an.bootcompsLoaded = an.bootcompsLoaded || [];
if(!an.bootstrapListeners) {
	an.bootstrapListeners=[];
}

an.bootstrapCallback=function(fnCallback) {
	an.bootstrapListeners.push(fnCallback);
	if(an.bootcompsLoaded.length > 0) {
		for(var i=0; i<an.bootcompsLoaded.length; ++i) {
			fnCallback(an.bootcompsLoaded[i]);
		}
	}
};

an.compositions = an.compositions || {};
an.compositions['150C87E02727DB4B8B9596BCEBF54E47'] = {
	getStage: function() { return exportRoot.stage; },
	getLibrary: function() { return lib; },
	getSpriteSheet: function() { return ss; },
	getImages: function() { return img; }
};

an.compositionLoaded = function(id) {
	an.bootcompsLoaded.push(id);
	for(var j=0; j<an.bootstrapListeners.length; j++) {
		an.bootstrapListeners[j](id);
	}
}

an.getComposition = function(id) {
	return an.compositions[id];
}


an.makeResponsive = function(isResp, respDim, isScale, scaleType, domContainers) {		
	var lastW, lastH, lastS=1;		
	window.addEventListener('resize', resizeCanvas);		
	resizeCanvas();		
	function resizeCanvas() {			
		var w = lib.properties.width, h = lib.properties.height;			
		var iw = window.innerWidth, ih=window.innerHeight;			
		var pRatio = window.devicePixelRatio || 1, xRatio=iw/w, yRatio=ih/h, sRatio=1;			
		if(isResp) {                
			if((respDim=='width'&&lastW==iw) || (respDim=='height'&&lastH==ih)) {                    
				sRatio = lastS;                
			}				
			else if(!isScale) {					
				if(iw<w || ih<h)						
					sRatio = Math.min(xRatio, yRatio);				
			}				
			else if(scaleType==1) {					
				sRatio = Math.min(xRatio, yRatio);				
			}				
			else if(scaleType==2) {					
				sRatio = Math.max(xRatio, yRatio);				
			}			
		}			
		domContainers[0].width = w * pRatio * sRatio;			
		domContainers[0].height = h * pRatio * sRatio;			
		domContainers.forEach(function(container) {				
			container.style.width = w * sRatio + 'px';				
			container.style.height = h * sRatio + 'px';			
		});			
		stage.scaleX = pRatio*sRatio;			
		stage.scaleY = pRatio*sRatio;			
		lastW = iw; lastH = ih; lastS = sRatio;            
		stage.tickOnUpdate = false;            
		stage.update();            
		stage.tickOnUpdate = true;		
	}
}
an.handleSoundStreamOnTick = function(event) {
	if(!event.paused){
		var stageChild = stage.getChildAt(0);
		if(!stageChild.paused){
			stageChild.syncStreamSounds();
		}
	}
}


})(createjs = createjs||{}, AdobeAn = AdobeAn||{});
var createjs, AdobeAn;