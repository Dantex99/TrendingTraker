   M S B A M L   `   `   `  ����I  ETrendingTraker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TrendingTrakerTrendingTraker  5   	       TrendingTraker.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TrendingTraker     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.2.1465, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     � Title$  TrendingTraker��5   	   $	��450��6    $	��580��6-   $
��Left=�69      MaterialDesignBody#���   5
   
   $��Regular"�5   
   $��13(�5   
   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignPaper#���  5   
     MaterialDesignFont#���  5   
   .��5      � -   5         �Name$ grd_TT��5      .+�5   
   �� -   5         ��Name$ btn_location��5      $��Mundial��6'   $��Center=�69   $��204,85,204,0q�6V   $	��Top=�6l   $	��164��6�   6�   �� 5   
   -   5         ��Name$ 	lbl_Title��5      $��TrendingTraker��6#   $��Center=�6<   $��0,31,0,0q�6Y   $	��Top=�6k   $��24(�6�   $��Center=�6�   $	��173��6�   �� 5   
   -   5         ��Name$ 	img_ayuda��5      $
��Left=�6#   $��20��6>   $	��Top=�6J   $��20��6b   $��img/Interrogante.png��6m   $��0,2,0,0q�6�   6�   #  MaterialDesignThemes.Wpf.Card  5   
   $��10q�6   $��
0,141,0,23q�6+   $��Center=�6?   .��5      � -   5        $ grd_TL��5      $��0q�6#   $	��350��6.   $	��255��6:   $��Center=�6G   .+�5      �� -   5         ��Name$ lbl_Tt1��5      $
��Left=�6-   $��	10,10,0,0q�6H   $	��Top=�6[   $	��150��6s   6   �� 5      -   5        $ lbl_Tt2��5      $
��Left=�6-   $��	10,57,0,0q�6H   $	��Top=�6[   $	��150��6s   6   �� 5      -   5        $ lbl_Tt3��5      $
��Left=�6-   $��
10,104,0,0q�6H   $	��Top=�6\   $	��150��6t   6�   �� 5      -	   5        $ lbl_Tt4��5      $
��Left=�6-   $��
10,151,0,0q�6H   $	��Top=�6\   $	��150��6t   6�   �� 5      -
   5        $ lbl_Tt5��5      $
��Left=�6-   $��
10,198,0,0q�6H   $	��Top=�6\   $	��150��6t   6�   �� 5      -   5        $ lbl_Tt6��5      $��Right=�6-   $��	0,10,10,0q�6I   $	��Top=�6\   $	��150��6t   6�   �� 5      -   5        $ lbl_Tt7��5      $��Right=�6-   $��	0,57,10,0q�6I   $	��Top=�6\   $	��150��6t   6�   �� 5      -   5        $ lbl_Tt8��5      $��Right=�6-   $��
0,104,10,0q�6I   $	��Top=�6]   $	��150��6u   6�   �� 5      -   5        $ lbl_Tt9��5      $��Right=�6-   $��
0,151,10,0q�6I   $	��Top=�6]   $	��150��6u   6�   �� 5       -   5        $ lbl_Tt10��5       $��Right=�6.   $��
0,198,10,0q�6J   $	��Top=�6^   $	��150��6v   6�   5!      5"      � 5#   
   -   5        $ 	grd_ayuda��5#      $y�Hidden=�6"   .+�5%        $��10q�6"   $��393,85,19,278q�6/   $��Center=�6F   .��5&      �� -   5        $ txb_ayudaBtn��5&      $0��*Pulsa para alternar entre España y Global��62   $
��Wrap=�6c    �� TextAlignment$ Center=�6w   $��0q�6�   $��Center=�6�   $��Center=�6�   5'        5)      $��10q�6"   $��371,329,10,10q�6/   $��Center=�6F   .��5*      �� -   5        $ txb_ayudalbl��5*      $E��?Elige la tendencia que quieres inspeccionar pulsando sobre ella��62   $
��Wrap=�6y   $ Center=�6�   $��Center=�6�   $��Center=�6�   $��50��6�   $��0,0,0,-2q�6�   5+        5-      $��5q�6"   $��15,35,386,293q�6.   $��Center=�6E   .��5.      �� -   5        $ 	txb_ayuda��5.      $U��OTrendingTraker visualiza las 10 tendencias actuales de la localización elegida��6/   $
��Wrap=�6�   $ Center=�6�   $��Center=�6�   $��0,0,0,1q�6�   $��Bottom=�6�   $��68��6�   5/      50      51      52      