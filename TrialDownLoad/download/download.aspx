<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="download.aspx.vb" Inherits="CST.CBT.eIPSTA.TrialDownLoad.download"  validateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="css/Style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
<script type="text/javascript" src="Scripts/jquery-1.4.1.min.js"></script>
    <title></title>
    </head>
<body>
    <div id="wrapper">
    <h2 class="menuTabLight" align="center">CBT方式動物看護師統一認定トライアルテストダウンロード</h2>
        <div id="main">
        <h3 class="menuLineDoubleLightW">使用方法</h3>
        <p>
        ・ダウンロード方法<br />
            　次の手順で、CBT方式トライアルテスト（以下、CBTテスト）をダウンロードしてください。<br />
          (1) 最下部「CBTテストダウンロード」ボタンをクリックし、CBTテスト（zip形式）をダウンロードしてください。<br />
          (2) ダウンロードしたファイルを解凍（展開）してください。<br />
          　　「CBT」というフォルダが作成され、フォルダの中に「CBT.msi」が作成されます。<br />
          (3) 解凍されたフォルダ内の「CBT.msi」をダブルクリックして、実行してください。<br />
          　　しばらくするとインストールが開始されますので、ソフトウェアをインストールしてください。<br />
          　　※.NET Framework3.5 SP1がインストールされていない場合は、インストール促すダイアログが表示されます。<br />
          　　　「はい」を選択するとマイクロソフト社のサイトに接続します。<br />
          　　　接続先の説明に従ってダウンロード及びインストールを行ってください。<br />
          　　　インストールが完了したら、再度「CBT.msi」をダブルクリックしてCBTテストのインストールを行ってください。
          <br />
          <br />
        ・実行方法<br />
            　次の手順でCBTテストを実行してください。<br />
          (1) デスクトップに「CBT体験試験」のショートカットが作成されますので、それをダブルクリックすると、<br />
  　　        CBTテストが実行されます。<br />
          (2) ログイン画面が表示されますので、送付されました書類を参照しながら、受験時間パターンを選択し、<br />
            　　記載のユーザーＩＤとパスワードを入力し、ログインボタンを押してください。<br />
          (3) 操作説明が表示されますので、操作説明を読んでCBTテストを操作してください。<br />
          (4) テストが終了しましたら、画面右上の「ログアウト」をクリックして、ログアウトしてください。<br />
  　　        自動的に、CBTテストがアンインストールされます。<br />
        </p>
                <p>
                    <br />
                    ※CBTテストの実行には、Windows XP(SP3)及びWindows Vistaでは.NET Framework 3.5 SP1が必要です。<br />
        Windows 7では.NET Framework 3.5.1が有効になっている必要があります <br />
        （.NET Framework 3.5.1はWindows7にプレインストールされています）。</p>
        </div>
        <form id="form1" runat="server" style="margin: 0px auto 0px auto;">
            <div style="margin: 40px auto 0px auto; width: 259px">
                <asp:Button type="submit" ID="btnDownLoad" runat="server" 
                    Text=" CBT方式テスト ダウンロード" Height="44px" 
                    Width="261px" Font-Bold="True" Font-Size="Medium" 
                    style="margin-left: 0px" />
                <br />
            </div>
        </form>
        <br />
        <br />
    </div>
</body>
</html>
