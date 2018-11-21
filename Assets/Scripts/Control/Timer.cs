using System;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// 计时器
/// <para>ZhangYu 2018-04-08</para>
/// </summary>
public class Timer : MonoBehaviour {

    public bool autoStart = false;
    // 当前时间
    public float currentTime = 0f;
    private GameObject timeText;
    private float lastTime;
    private int currentCount;
    private GameObject timer;
    
    private void Start () {
        enabled = autoStart;
        timer = GameObject.FindGameObjectWithTag("Timer");
        Debug.Log(timer);
    }

    void FixedUpdate () {
        Debug.Log("Time");
        if (GameSet.Instance.gameSituation==EGameProcess.PlayGame){         
            currentTime += Time.deltaTime;
            timer.GetComponent<Text>().text = currentTime.ToString("f2");}
    }

    
    /// <summary> 增加间隔时间 </summary>
    /*private void addInterval(float deltaTime) {
        currentTime += deltaTime;
        if (currentTime < delay) return;
        if (currentTime - lastTime >= interval) {
            currentCount++;
            lastTime = currentTime;
            if (repeatCount <= 0) {
                // 无限重复
                if (currentCount == int.MaxValue) reset();
                if (onIntervalCall != null) onIntervalCall(this);
                if (onIntervalEvent != null) onIntervalEvent.Invoke();
            } else {
                if (currentCount < repeatCount) {
                    //计时间隔
                    if (onIntervalCall != null) onIntervalCall(this);
                    if (onIntervalEvent != null) onIntervalEvent.Invoke();
                } else {
                    //计时结束
                    stop();
                    if (onCompleteCall != null) onCompleteCall(this);
                    if (onCompleteEvent != null) onCompleteEvent.Invoke();
                    if (autoDestory && !enabled) Destroy(this);
                }
            } 
        }
    }*/

    /// <summary> 开始/继续计时 </summary>
    public void start() {
        enabled = autoStart = true;
    }
    
    /*
    /// <summary> 开始计时 </summary>
    /// <param name="time">时间(秒)</param>
    /// <param name="onComplete(Timer timer)">计时完成回调事件</param>
    public void start(float time, TimerCallback onComplete) {
        start(time, 1, null, onComplete);
    }

    /// <summary> 开始计时 </summary>
    /// <param name="interval">计时间隔</param>
    /// <param name="repeatCount">重复次数</param>
    /// <param name="onComplete(Timer timer)">计时完成回调事件</param>
    public void start(float interval, int repeatCount, TimerCallback onComplete) {
        start(interval, repeatCount, null, onComplete);
    }

    /// <summary> 开始计时 </summary>
    /// <param name="interval">计时间隔</param>
    /// <param name="repeatCount">重复次数</param>
    /// <param name="onInterval(Timer timer)">计时间隔回调事件</param>
    /// <param name="onComplete(Timer timer)">计时完成回调事件</param>
    public void start(float interval, int repeatCount, TimerCallback onInterval, TimerCallback onComplete) {
        this.interval = interval;
        this.repeatCount = repeatCount;
        onIntervalCall = onInterval;
        onCompleteCall = onComplete;
        reset();
        enabled = autoStart = true;
    }*/

    /// <summary> 暂停计时 </summary>
    public void stop() {
        //enabled = autoStart = false;
    }

    /// <summary> 停止Timer并重置数据 </summary>
    public void reset(){
        lastTime = currentTime = currentCount = 0;
        timer.GetComponent<Text>().text = "0.00";
    }

    /// <summary> 重置数据并重新开始计时 </summary>
    public void restart() {
        reset();
        start();
    }

}