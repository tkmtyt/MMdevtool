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

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください
namespace MMdevtool
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        SearchPivot search_pivot;
        public MainPage()
        {
            this.InitializeComponent();
            search_pivot = new SearchPivot();                            //search_pivotクラスのインスタンスを作り、コンストラクタを実行(ここはvar search_pivot...とは書かないのか？).
                                                                         // [ans] var...はローカル変数で、コンパイラが型を推測できる時に限って使える省略記法です。
                                                                         //       たとえば、Pillar p = new Pillar(); だと、右側だけで型が確定するはずなのに、2回型を書いていて無駄が多い 　みたいな感じです。
                                                                         //       ここでは、クラスメンバのMainPage.search_pivot を初期化しているので、こうなります。
        }

        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            this.DrawPillar(search_pivot.make_pillars.Pillars);                      //DrawPillarメソッドに先ほどインスタンス化したsearch_pivotのPillarsの値を渡す（値では無くてポインタを渡している？？）.
                                                                                     // [ans] C#では、プリミティブ型(intとかdouble)以外を扱う時は基本的にすべて参照(ポインタ的な物)で、値を直接扱う事はありません。
                                                                                     //       MainPage.search_pivotもC的表現で言えば、SearchPivot * 型です。
            this.DrawWall(search_pivot.make_walls.Walls);
        }


        private void DrawPillar(IEnumerable<Pillar> pillars)            //DrawPillarメソッドはIEnumerable型のPillar(ジェネリッククラス？）をpillarsとして受け取る（キャストみたいなもの？）.
                                                                        // [ans] IEnumerable<T>は、T型のEnumerableな物(列挙できる=配列っぽい使い方ができる物なんでも)を表すジェネリックインタフェースです。
                                                                        //       こうしておくと、下で使っているList<T>や、固定長の配列を何でも受け付けるようになるので便利です。
        {
            foreach (var p in pillars)
            {
                var r = new Rectangle();                                //Rectangleクラスのrというインスタンスを作り、コンストラクタを実行

                r.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                r.Width = 3;
                r.Height = 3;
                this.map_canvas.Children.Add(r);                        //map_canvasに描画(Childrenって何なの？).
                                                                        // [ans] ChildrenはCanvasクラスのメンバで、Canvasクラスはここに追加された要素を描画するように作られているという感じですね。
                Canvas.SetLeft(r, p.X * 30 + 3);                        //描画後位置移動.
                                                                        // [ans] 実はこれが一番やっかいな記述なんですが、ひとまずスルーで良いと思います・・・
                Canvas.SetTop(r, p.Y * 30 + 3);
            }
        }
        private void DrawWall(IEnumerable<Wall> walls)            
        {
            foreach (var p in walls)
            {
                var r = new Rectangle();                                //Rectangleクラスのrというインスタンスを作り、コンストラクタを実行

                r.Fill = new SolidColorBrush(Windows.UI.Colors.DarkRed);
                r.Width = 3;
                r.Height = 27;
                this.map_canvas.Children.Add(r);                        //map_canvasに描画(Childrenって何なの？).
                                                                        // [ans] ChildrenはCanvasクラスのメンバで、Canvasクラスはここに追加された要素を描画するように作られているという感じですね。
                Canvas.SetLeft(r, p.X * 30 + 3);                        //描画後位置移動.
                                                                        // [ans] 実はこれが一番やっかいな記述なんですが、ひとまずスルーで良いと思います・・・
                Canvas.SetTop(r, p.Y * 30 + 3+3);
            }
        }


    }

}