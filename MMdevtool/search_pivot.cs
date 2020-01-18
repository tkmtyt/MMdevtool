using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//追加.
using Windows.UI.Xaml.Shapes;



class SearchPivot
{
    public MakePillars make_pillars { get; set; }
    public MakeWalls make_walls { get; set; }


    public SearchPivot()                                        //SearchPivotコンストラクタ.
    {
        make_pillars = new MakePillars();
        make_walls = new MakeWalls();
    }

}

class MakeWalls
{
    public List<Wall> Walls { get; private set; }

    public MakeWalls()
    {
        this.Walls = new List<Wall>();
        foreach(var y in Enumerable.Range(0, 31))
        {
            foreach(var x in Enumerable.Range(0,32))
            {
                this.Walls.Add(new Wall(x, y, false));
            }
        }

    }

}


class MakePillars
{
    public List<Pillar> Pillars { get; private set; }           //List型のPillarでPollarsというメソッド生成...じゃない？これ何…？ [1].
                                                                // [ans] {get;set;}の書き方は、プロパティという機能です。メソッドであり変数であるような性質の物です。
                                                                //       クラスの外から値の取得、セットをするためのgetter/setter メソッドを簡略化して書けるものです。
                                                                //       ここでは、private set と書いて、SearchPivotクラスの外からPillarsを書き換えられないようにしています。
    public MakePillars()
    {

        this.Pillars = new List<Pillar>();                      //List型のPillarでPillarsをインスタンス化.
                                                                // [ans] C#で配列を使う事はほとんどなくて、複数の要素を持ちたい時は、List<T>型やDictionary<K,V>を使う事が多いです

        foreach (var y in Enumerable.Range(0, 32))              //Enumerable.Rangeの部分は0～32までを生成するため.
                                                                // [ans] for文を生で書くのはバグの元なのでやめようというのがイマドキなプログラミングの流れです
        {
            foreach (var x in Enumerable.Range(0, 32))
            {
                this.Pillars.Add(new Pillar(x, y));             //[1]で作ったメソッド？インスタンス？にListの要素を追加.
                                                                // [ans] List<Pillar>型の変数と思って大丈夫です

            }

        }
    }

}

class Pillar
{
    public int X { get; set; }
    public int Y { get; set; }

    public Rectangle R { get; set; }


    public Pillar(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

}

class Wall
{
    public int X { get; set; }
    public int Y { get; set; }
    bool IsExist { get; set; }

    public Wall(int x,int y,bool is_exist)
    {
        this.X = x;
        this.Y = y;
        this.IsExist = is_exist;
    }
}