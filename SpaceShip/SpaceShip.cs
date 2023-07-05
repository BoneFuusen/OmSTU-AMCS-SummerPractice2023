using System.Collections.Generic;
using System;

namespace SpaceShip;
public class SpaceShip
{
    //WHEAT//
}

public class Pool<T> where T : new()
{
    public readonly Stack<T> pool;

    public Pool(){
        pool = new Stack<T>();
    }

    public T GetObject(){
        if (pool.Count > 0){
            return pool.Pop();
        }
              
        return new T();
    }

    public void ReturnObject(T obj){
        pool.Push(obj);
    }
}
public class PoolGuard<T> : IDisposable where T : new()
{
    private readonly T obj;
    private readonly Pool<T> pool;

    public PoolGuard(Pool<T> pool){
        this.pool = pool;
        obj = pool.GetObject();
    }

    public void Dispose(){
        pool.ReturnObject(obj);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Pool<SpaceShip> spaceShipPool = new Pool<SpaceShip>();

        using (var guard = new PoolGuard<SpaceShip>(spaceShipPool)){
            //WORKING WITH OBJECT (VERY-VERY IMPORTANT)//

            SpaceShip spaceShip= spaceShipPool.GetObject();

            //MANIPULATIONS WITH OBJECT//
        }
        //AFTER LEAVING `using`, object automatically returns to its pool//
    }
}