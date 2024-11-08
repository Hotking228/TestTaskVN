using Naninovel;
using Naninovel.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[CommandAlias("addScore")]
public class AddScore : Command 
{
    [ParameterAlias(NamelessParameterAlias)]
    public IntegerParameter score;
    
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {

        PlayerBag.Instance.ChangeScore(score);

        return UniTask.CompletedTask;
    }
}
[CommandAlias("checkScore")]
public class CheckScore : Command
{


    [ParameterAlias(NamelessParameterAlias)]
    public IntegerParameter reqiuredScore;

    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        Engine.GetService<CustomVariableManager>().SetVariableValue("anouthScore", PlayerBag.Instance.CheckScore(reqiuredScore).ToString());

        return UniTask.CompletedTask; 
    }
}
[CommandAlias("showScorePanel")]
public class ShowScorePanel : Command
{


    [ParameterAlias(NamelessParameterAlias)]
    public IntegerParameter reqiuredScore;

    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        PlayerBag.Instance.ShowScore();

        return UniTask.CompletedTask;
    }
}