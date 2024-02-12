using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable 
{
    //TODO:这个接口是为了通用给所有能够在“地图”上移动的物体的
    //移动分为主动和被动，例如玩家主动向左走，分别会有俩种情况 1：左边是不可行走的区域 2：左边有另一个Moveable的物体。
    //如果是第一种情况，则简单的跳出不让行走即可
    //第二种情况需要判断，该Moveable是否可以被动移动，如果可以的话则被动移动。
    //假定所有的移动速度都是一样的，则可以主动移动和被动移动都向目标方向移动
    //被动移动就是被主动移动驱使着移动，例如推箱子之类的，或者行人被推一下，不过推行人感觉做成互动比较好

    //所有带着这个接口的物体都可以主动移动，所以不需要主动移动的标志位
    //标志位，是否可以被动移动
    bool CanMovePassivity { get;}



    
}
