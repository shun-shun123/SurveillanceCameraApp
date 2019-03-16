# 監視カメラアプリ

# 機能要件
## フロントエンド
* ラズパイからの動画をリアルタイムで取得する
* LINEアカウントを登録して通知を受け取れる
* 顔認識のために内カメで動画を撮る
* 人の顔を録画した動画を、人物情報とともにサーバに送る

## ラズパイ
* 動きを検知する
* 動きを検知した時にそのフレーム画像をサーバに送信する
* サーバから結果を受信する

## サーバ
* 送られた人物画像をもとにトレーニングセットを作る
* POSTで送られた画像に対して人を検知する
* 人がいるのならTrue, いないならFalseを返す

# スケジュール
## 4月中
* ラズパイからの動画をリアルタイムで取得する

## ~ 8/1
* 顔認識のために内カメで動画を撮る
* 人の顔を録画した動画を、人物情報とともにサーバに送る
* POSTで送られた画像に対して人を検知する
* 人がいるのならTrue, いないならFalseを返す