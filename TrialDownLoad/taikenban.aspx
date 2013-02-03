<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head><link href="Style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="scripts/jquery-1.4.1.js"></script>
<script type="text/javascript" src="scripts/jquery-1.4.1.min.js"></script>
    <title></title>
<script language="Javascript">
HPB_script_CODE_40
function _HpbImgSwap(imgName, imgSrc)
{
  var appVer=parseInt(navigator.appVersion);
  var isNC=false,isN6=false,isIE=false;
  if (document.all && appVer >= 4) isIE=true; else
    if (document.getElementById && appVer > 4) isN6=true; else
      if (document.layers && appVer >= 4) isNC=true;
  if (isNC||isN6||isIE)
  {
    if (document.images)
    {
      var img = document.images[imgName];
      if (!img) img = _HpbImgFind(document, imgName);
      if (img) img.src = imgSrc;
    }
  }
}

function _HpbImgFind(doc, imgName)
{
  for (var i=0; i < doc.layers.length; i++)
  {
    var img = doc.layers[i].document.images[imgName];
    if (!img) img = _HpbImgFind(doc.layers[i], imgName);
    if (img) return img;
  }
  return null;
}
</script></head>
<body>
<form id="Form1" method="post" runat="server">
    <div id="wrapper">
    <h1 class="menuTabLight" >コンピュータ試験システム(CBT)体験版ダウンロード</h1></div>
        <div id="main">
        <h2 class="menuLineDoubleLightW"><FONT size="4pts" face="メイリオ">下記をお読みになってからダウンロード頂けます様お願い致します。</h2></div>
        <div style="top : 120px;left : 100px;
  position : absolute;
  z-index : 8;
" id="Layer1"><h4><ul><li>ダウンロード方法</li></ul></div></h4>
             <div style="top : 180px;left : 130px;
  position : absolute;
  z-index : 8;
" id="Layer2"><FONT size="2.8pts" face="メイリオ">
          (1) 最下部「体験版ダウンロード」ボタンをクリックし、体験版（zip形式）をダウンロードしてください。<br />
          (2) ダウンロードしたファイルを解凍（展開）してください。<br />
              「CBT」というフォルダが作成され、フォルダの中に「CBT.msi」が作成されます。<br />
          (3) 解凍されたフォルダ内の「CBT.msi」をダブルクリックして、実行してください。<br />
              しばらくするとインストールが開始されますので、ソフトウェアをインストールしてください。<br />
              ※.NET Framework3.5 SP1がインストールされていない場合は、インストール促すダイアログが表示されます。<br />
              「はい」を選択するとマイクロソフト社のサイトに接続します。<br />
              接続先の説明に従ってダウンロード及びインストールを行ってください。<br />
              インストールが完了したら、再度「CBT.msi」をダブルクリックして体験版のインストールを行ってください。</div>
          <br />
          <br />
          <div style="top : 380px;left : 100px;
  position : absolute;
  z-index : 8;
" id="Layer3"><h4><ul><li> 実行方法</li></ul></h4></div>
                 <div style="top : 440px;left : 130px;
  position : absolute;
  z-index : 8;
" id="Layer4"><FONT size="2.8pts" face="メイリオ">
          次の手順でCBT体験版を実行してください。<br />
          (1) デスクトップに「CBT体験版」のショートカットが作成されますので、それをダブルクリックすると、<br />
              CBT体験版が実行されます。<br />
          (2) ログイン画面が表示されますので、何も入力せずにログインボタンを押してください。<br />
          (3) 操作説明が表示されますので、操作説明を読んでCBT体験版を操作してください。<br />
          (4) 体験が終了しましたら、画面右上の「ログアウト」をクリックして、ログアウトしてください。<br />
              自動的に、CBT体験版がアンインストールされます。<br /></div>
          <br />
          <br />
           <div style="top :600px;left : 100px;
  position : absolute;
  z-index : 8;
" id="Layer5"><h4><ul><li> 推奨動作環境</li></ul></h4></div>
         <div style="top : 660px;left : 130px;
  position : absolute;
  z-index : 8;
" id="Layer6"><FONT size="2.8pts" face="メイリオ">
                ○ PC 規格:PC-AT 機またはそれに相当する互換機。及び下記のOS が正常動作する情報端末。<br />
                ○ CPU インテル Core2Duo シリーズ・Corei シリーズ　＊ もしくはこれらの互換プロセッサー<br />
                ○ 搭載メモリ:1GB 以上<br />
                ○ OS:日本語版　WindowsXP,WindowsVista,Windows７</br>
                 ＊ 上記のOS の動作基準を超えたパソコンのご利用を推奨致します。<br />
                ○ ブラウザ InternetExplorer6.0　以降<br />
                ○ その他 .NETFramework3.5SP1  <br />
                    ※体験版の実行には、Windows XP(SP3)及びWindows Vistaでは.NET Framework 3.5 SP1が必要です。<br />
                      Windows 7では.NET Framework 3.5.1が有効になっている必要があります <br />
                     （.NET Framework 3.5.1はWindows7にプレインストールされています）。</B></FONT></div>
<div style="top : 900px;left : 390px;
  position : absolute;
  z-index : 8;
" id="Layer7"><h2><FONT size="2.8pts" face="メイリオ">下のボタンをクリックしてダウンロード！</h2></div>
<div style="top : 920px;left : 400px;
  position : absolute;
  z-index : 11;
" id="Layer8"><A href="index.html"><IMG src="img/taikendown_button.png" border="0" width="200" height="60"border="0" onmouseover="_HpbImgSwap('btnLink6', 'img/taikendown_button-1.png');" onmouseout="_HpbImgSwap('btnLink6', 'img/taikendown_button.png');" name="btnLink6" alt="コンピュータ試験システム"></A></div>
<div style="top : 900px;left : 750px;
  position : absolute;
  z-index : 8;
" id="Layer7"><h5><FONT size="1.5pts" face="メイリオ">お気軽にお問い合わせ下さい！</h5></div>
<div style="top : 930px;left : 770px;
  position : absolute;
  z-index : 11;
" id="Layer8"><A href="index.html"><IMG src="img/mail.png" border="0" width="75" height="50"border="0" alt="mail"></A></div>
</br>
</br>
<div style="top : 1000px;left : -4px;
  position : absolute;
  z-index : 1;
  visibility : visible;
" id="Layer12">
<div>
<TABLE cellspacing="0" cellpadding="2" width="1000" height="44">
  <TBODY>
    <TR>
      <TD colspan="5">
      <HR size="16" style="background-image : url(o3b.gif);" width="1000" align="left">
      </TD>
    </TR>
    <TR>
      <TD colspan="5" align="center"><FONT color="#000000"><SPAN style="font-size: 12">Copyright(C) 2008-2013 CS Technology Co., Ltd. All Rights Reserved</SPAN></FONT></TD>
    </TR>
  </TBODY>
</TABLE>
</div>
</div>
</body>
</html>
