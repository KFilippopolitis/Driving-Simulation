using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PriorityQueue<Tname, Trng, TPriority, Tlane> where TPriority : IComparable<TPriority>
{
    List<TPriority> priority;
    List<Trng> rng;
    List<Tname> name;
    List<Tlane> lane;

    public PriorityQueue()
    {
        this.priority = new List<TPriority>();
        this.rng = new List<Trng>();
        this.name = new List<Tname>();
        this.lane = new List<Tlane>();

    }
    public void Enqueue(Tname nameItem, Trng rngItem, TPriority priorityItem, Tlane laneItem)
    {
        priority.Add(priorityItem);
        rng.Add(rngItem);
        lane.Add(laneItem);
        name.Add(nameItem);
        int childIndex = priority.Count - 1;
        while (childIndex > 0)
        {
            int parentIndex = (childIndex - 1) / 2;

            if (priority[childIndex].CompareTo(priority[parentIndex]) >= 0)
            {
                break;
            }
            ChildToParent(childIndex,parentIndex);
            childIndex = parentIndex;
        }

    }
    public void Dequeque()
    {

        int lastIndex = priority.Count - 1;
        priority[0] = priority[lastIndex];
        name[0] = name[lastIndex];
        rng[0] = rng[lastIndex];
        lane[0] = lane[lastIndex];
        priority.RemoveAt(lastIndex);
        name.RemoveAt(lastIndex);
        rng.RemoveAt(lastIndex);
        lane.RemoveAt(lastIndex);
        lastIndex--;

        int parentIndex = 0;

        while (true)
        {
            int childIndex = parentIndex * 2 + 1;

            if (childIndex > lastIndex)
            {
                break;
            }

            int rightchild = childIndex + 1;
            if (rightchild <= lastIndex && priority[rightchild].CompareTo(priority[childIndex]) < 0)
            {
                childIndex = rightchild;
            }
            if (priority[parentIndex].CompareTo(priority[childIndex]) <= 0)
            {
                break;
            }
            ChildToParent(parentIndex, childIndex);
            parentIndex = childIndex;
        }
    }
    public TPriority PeekPriority()
    {
        TPriority frontItem = priority[0];
        return frontItem;
    }
    public Tname PeekName()
    {
        Tname frontItem = name[0];
        return frontItem;
    }
    public Trng PeekRng()
    {
        Trng frontItem = rng[0];
        return frontItem;
    }
    public Tlane PeekLane()
    {
        Tlane frontItem = lane[0];
        return frontItem;
    }
    public int Count() { return priority.Count; }
    private void ChildToParent(int index1,int index2)
    {
        Trng tempRng = rng[index1];
        rng[index1] = rng[index2];
        rng[index2] = tempRng;

        TPriority tempPriority = priority[index1];
        priority[index1] = priority[index2];
        priority[index2] = tempPriority;

        Tlane templane = lane[index1];
        lane[index1] = lane[index2];
        lane[index2] = templane;

        Tname tempName = name[index1];
        name[index1] = name[index2];
        name[index2] = tempName;
    }
    
}
