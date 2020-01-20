using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Queue<Tname, Trng, TPriority,Tlane> where TPriority : IComparable<TPriority>
{
    List<TPriority> priority;
    List<Trng> rng;
    List<Tname> name;
    List<Tlane> lane;

    public Queue()
    {
        this.priority = new List<TPriority>();
        this.rng = new List<Trng>();
        this.name = new List<Tname>();
        this.lane = new List<Tlane>();

    }
    public void Enqueue(Tname nameItem, Trng rngItem, TPriority priorityItem,Tlane laneItem)
    {
        priority.Add(priorityItem);
        rng.Add(rngItem);
        name.Add(nameItem);
        lane.Add(laneItem);
    }
    public void Dequeque()
    {
        priority.RemoveAt(0);
        name.RemoveAt(0);
        rng.RemoveAt(0);
        lane.RemoveAt(0);
    }
    public TPriority PeekPriority()
    {
        TPriority frontItem = priority[0];
        return frontItem;
    }
    public Trng PeekRng()
    {
        Trng frontItem = rng[0];
        return frontItem;
    }
    public Tname PeekName()
    {
        Tname frontItem = name[0];
        return frontItem;
    }
    public Tlane PeekLane()
    {
        Tlane frontItem = lane[0];
        return frontItem;
    }
    public int Count() { return priority.Count; }
   
}

