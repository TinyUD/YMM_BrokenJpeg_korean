# Broken Jpeg

## is何

* 画像をJPEG画像に圧縮し、そのデータを意図的に壊すことで、特有の効果を適用します。

## ダウンロード

* Releasesからymmeファイルをダウンロードしてください。

## インストール

* 拡張子の関連付けを行っている場合は、ymmeファイルをダブルクリックします。
* 関連付けを行っていない場合はYukkuriMovieMaker.exeにドラッグ&ドロップします。
    * もしくは拡張子をzipに変更、解凍したdllファイルをpluginディレクトリにコピーします。

## アンインストール

* pluginディレクトリからYMM_BrokenJpeg.dll、YMM_BrokenJpegディレクトリがある場合はディレクトリごと削除します。

## 使用方法

* 映像エフェクトの加工からBroken Jpegを適用します。

### パラメータ

* 圧縮品質
    * JPEGに圧縮する際の品質です。
* サブサンプリング
    * JPEGに圧縮する際、の色差信号を間引く比率を指定します。
* 背景色
    * JPEGに圧縮する際、透明部分の背景色を指定します。
    * JPEGではα値は保持されないため、事前に指定した背景色で塗りつぶされたイメージの上にレイヤーの画像を描画してから圧縮します。
* 画像の破損
    * 破損箇所数
        * 圧縮された画像データを壊す数を指定します。
        * 壊す箇所が多くなれば多くなるほど見た目も壊れますが、数が多すぎるとほとんど単色のようなイメージになります
    * 破損範囲開始
    * 破損範囲終了
        * 画像データを壊す範囲を指定します。
    * ランダムシード
        * 画像の壊し方のシード値です。
* 量子化テーブル(輝度/色差)の破損
    * 有効/無効
        * JPEGの量子化テーブルを壊すかどうかを設定します。
    * 破損箇所
        * 量子化テーブルを壊す位置を指定します。
        * テーブルの特定の位置だけ壊します。
    * 値
        * 破損箇所で指定した位置の値をこの値で置き換えます。
    * 破損箇所数
        * 量子化テーブルをランダムに壊す個数を指定します。
    * 最大値
        * 量子化テーブルを壊す際の値の最大値を指定します。
    * ランダムシード
        * 量子化テーブルをランダムに壊す際のシード値です。

## 注意点等

* 画像全体に適用できるようにするため、内部でビットマップを生成している関係上、エフェクトの組み合わせなどによってYMMが落ちる可能性があります。
    * YMMが落ちる場合はそのエフェクトの組み合わせやこのエフェクト自体を使用しないようにしてください。
* あまりにも大きすぎる画像(1辺が16384px以上)の場合、画像が途切れるため、これ以下に押さえてください。
    * 使用している素材自体は小さい場合でも、エフェクトの適用によってサイズが大きくなる場合があります。
* JPEG画像を意図的に壊しているため、壊れ方によっては何も表示されないことがあります。
* JPEGに圧縮する都合上、背景が不透明になります。
* 破損のしかたによって、かなり激しい点滅を伴うことがあります。使用する際は破損範囲開始を少し大きめにするか、画面全体を暗くする、フレームレートを落とすなどで点滅を和らげることをおすすめします。

## ライセンス

* MIT