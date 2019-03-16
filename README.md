# 監視カメラアプリ

# 機能要件
## フロントエンド:sunny:
* ラズパイからの動画をリアルタイムで取得する
* LINEアカウントを登録して通知を受け取れる
* 顔認識のために内カメで動画を撮る
* 人の顔を録画した動画を、人物情報とともにサーバに送る

## ラズパイ:umbrella:
* 動きを検知する
* 動きを検知した時にそのフレーム画像をサーバに送信する
* サーバから結果を受信する

## サーバ:cloud:
* 送られた人物画像をもとにトレーニングセットを作る
* POSTで送られた画像に対して人を検知する
* 人がいるのならTrue, いないならFalseを返す

# スケジュール
フロント :sunny:

ラズパイ :umbrella:

サーバ :cloud:
## 4月中
* :sunny:ラズパイからの動画をリアルタイムで取得する

## ~ 8/1
* :sunny:顔認識のために内カメで動画を撮る
* :sunny:人の顔を録画した動画を、人物情報とともにサーバに送る
* :cloud:POSTで送られた画像に対して人を検知する
* :cloud:人がいるのならTrue, いないならFalseを返す