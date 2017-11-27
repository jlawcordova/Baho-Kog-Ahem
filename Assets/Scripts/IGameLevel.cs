using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameLevel {
	event EventHandler GameLevelEnded;

    Difficulty DifficultyLevel { get; set; }
}
