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
    <h1 class="menuTabLight" >�R���s���[�^�����V�X�e��(CBT)�̌��Ń_�E�����[�h</h1></div>
        <div id="main">
        <h2 class="menuLineDoubleLightW"><FONT size="4pts" face="���C���I">���L�����ǂ݂ɂȂ��Ă���_�E�����[�h�����܂��l���肢�v���܂��B</h2></div>
        <div style="top : 120px;left : 100px;
  position : absolute;
  z-index : 8;
" id="Layer1"><h4><ul><li>�_�E�����[�h���@</li></ul></div></h4>
             <div style="top : 180px;left : 130px;
  position : absolute;
  z-index : 8;
" id="Layer2"><FONT size="2.8pts" face="���C���I">
          (1) �ŉ����u�̌��Ń_�E�����[�h�v�{�^�����N���b�N���A�̌��Łizip�`���j���_�E�����[�h���Ă��������B<br />
          (2) �_�E�����[�h�����t�@�C�����𓀁i�W�J�j���Ă��������B<br />
              �uCBT�v�Ƃ����t�H���_���쐬����A�t�H���_�̒��ɁuCBT.msi�v���쐬����܂��B<br />
          (3) �𓀂��ꂽ�t�H���_���́uCBT.msi�v���_�u���N���b�N���āA���s���Ă��������B<br />
              ���΂炭����ƃC���X�g�[�����J�n����܂��̂ŁA�\�t�g�E�F�A���C���X�g�[�����Ă��������B<br />
              ��.NET Framework3.5 SP1���C���X�g�[������Ă��Ȃ��ꍇ�́A�C���X�g�[�������_�C�A���O���\������܂��B<br />
              �u�͂��v��I������ƃ}�C�N���\�t�g�Ђ̃T�C�g�ɐڑ����܂��B<br />
              �ڑ���̐����ɏ]���ă_�E�����[�h�y�уC���X�g�[�����s���Ă��������B<br />
              �C���X�g�[��������������A�ēx�uCBT.msi�v���_�u���N���b�N���đ̌��ł̃C���X�g�[�����s���Ă��������B</div>
          <br />
          <br />
          <div style="top : 380px;left : 100px;
  position : absolute;
  z-index : 8;
" id="Layer3"><h4><ul><li> ���s���@</li></ul></h4></div>
                 <div style="top : 440px;left : 130px;
  position : absolute;
  z-index : 8;
" id="Layer4"><FONT size="2.8pts" face="���C���I">
          ���̎菇��CBT�̌��ł����s���Ă��������B<br />
          (1) �f�X�N�g�b�v�ɁuCBT�̌��Łv�̃V���[�g�J�b�g���쐬����܂��̂ŁA������_�u���N���b�N����ƁA<br />
              CBT�̌��ł����s����܂��B<br />
          (2) ���O�C����ʂ��\������܂��̂ŁA�������͂����Ƀ��O�C���{�^���������Ă��������B<br />
          (3) ����������\������܂��̂ŁA���������ǂ��CBT�̌��ł𑀍삵�Ă��������B<br />
          (4) �̌����I�����܂�����A��ʉE��́u���O�A�E�g�v���N���b�N���āA���O�A�E�g���Ă��������B<br />
              �����I�ɁACBT�̌��ł��A���C���X�g�[������܂��B<br /></div>
          <br />
          <br />
           <div style="top :600px;left : 100px;
  position : absolute;
  z-index : 8;
" id="Layer5"><h4><ul><li> ���������</li></ul></h4></div>
         <div style="top : 660px;left : 130px;
  position : absolute;
  z-index : 8;
" id="Layer6"><FONT size="2.8pts" face="���C���I">
                �� PC �K�i:PC-AT �@�܂��͂���ɑ�������݊��@�B�y�щ��L��OS �����퓮�삷����[���B<br />
                �� CPU �C���e�� Core2Duo �V���[�Y�ECorei �V���[�Y�@�� �������͂����̌݊��v���Z�b�T�[<br />
                �� ���ڃ�����:1GB �ȏ�<br />
                �� OS:���{��Ł@WindowsXP,WindowsVista,Windows�V</br>
                 �� ��L��OS �̓����𒴂����p�\�R���̂����p�𐄏��v���܂��B<br />
                �� �u���E�U InternetExplorer6.0�@�ȍ~<br />
                �� ���̑� .NETFramework3.5SP1  <br />
                    ���̌��ł̎��s�ɂ́AWindows XP(SP3)�y��Windows Vista�ł�.NET Framework 3.5 SP1���K�v�ł��B<br />
                      Windows 7�ł�.NET Framework 3.5.1���L���ɂȂ��Ă���K�v������܂� <br />
                     �i.NET Framework 3.5.1��Windows7�Ƀv���C���X�g�[������Ă��܂��j�B</B></FONT></div>
<div style="top : 900px;left : 390px;
  position : absolute;
  z-index : 8;
" id="Layer7"><h2><FONT size="2.8pts" face="���C���I">���̃{�^�����N���b�N���ă_�E�����[�h�I</h2></div>
<div style="top : 920px;left : 400px;
  position : absolute;
  z-index : 11;
" id="Layer8"><A href="index.html"><IMG src="img/taikendown_button.png" border="0" width="200" height="60"border="0" onmouseover="_HpbImgSwap('btnLink6', 'img/taikendown_button-1.png');" onmouseout="_HpbImgSwap('btnLink6', 'img/taikendown_button.png');" name="btnLink6" alt="�R���s���[�^�����V�X�e��"></A></div>
<div style="top : 900px;left : 750px;
  position : absolute;
  z-index : 8;
" id="Layer7"><h5><FONT size="1.5pts" face="���C���I">���C�y�ɂ��₢���킹�������I</h5></div>
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
