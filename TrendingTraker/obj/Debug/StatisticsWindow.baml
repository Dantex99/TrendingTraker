   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5   	   I ETrendingTraker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TrendingTrakerTrendingTraker 5   	   %   TrendingTraker.StatisticsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   .localclr-namespace:TrendingTraker     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.2.1465, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  
Statistics��5
   	   $	��480��6   $	��855��6)      MaterialDesignBody#���   5   
   $��Regular"�5   
   $��13(�5   
   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignPaper#���  5   
     MaterialDesignFont#���  5   
   .��5      � -   5         �Name$ grd_general��5      .+�5   
   � -   5        $ 	grd_datos��5      .+�5      #  MaterialDesignThemes.Wpf.Card  $��2q�6"   $��
0,10,0,403q�6.   $��Center=�6B   .��5      �� -   5         ��Name$ lbl_SelectTt��5      $��Prueba��6.   $��Center=�6?   $
��60,0q�6\   $��Center=�6j   5      �� 5      -   5         ��Name$ 	img_ayuda��5      $
��Left=�6'   $��20��6B   $	��Top=�6N   $��20��6f   $��img/Interrogante.png��6q   $��0,2,0,0q�6�   6�     5      $��2q�6"   $��174,60,173,343q�6.   ���	#FF1DA1F2$��1q�6^   .��5      � -   5        $ grd_data��5      $��
10,0,6,-10q�6)   .+�5      �� -   5        $ lbl_tTweets��5      $��	Tweets TT��61   $��Right=�6E   $��0,9,5,10q�6a   $��Center=�6s   $��33��6�   �� 5      -   5        $ lbl_gTweets��5      $��
Tweets glb��61   $
��Left=�6F   $��5,9,0,10q�6a   $��Center=�6s   $��33��6�   �� 5       -   5        $ lbl_impacto��5       $$��Un x % del mundo habla de esto��61   $��Center=�6Z   $��158,8,128,10q�6w   $��Center=�6�   $��34��6�   5!      5"      �� 5$      -	   5         ��Name$ btn_recargar��5$      $��Recargar��6+   $��Right=�6>   $��0,190,594,0q�6Z   $	��Top=�6o   $	��122��6�   ���	#FF1DA1F2���	#FF042C44$��29��6�   6�   �� 5%      -
   5        $ btn_goTwitter��5%      $��Ir a Twitter��6,   $��Right=�6C   $��0,190,132,0q�6_   $	��Top=�6t   $	��122��6�   ���	#FF1DA1F2���	#FF042C44$��29��6�   6�     5'      $��2q�6"   $��
0,224,0,10q�6.   $��Center=�6B   .��5)      � -   5        $ grd_popularTweet��5)      $��	10,10,6,6q�61   $��Center=�6D   $	��579��6a   .+�5*      A� -   5         A�Name$ img_profile��5*      $
��Left=�63   $��80��6N   $��	10,10,0,0q�6Z   $	��Top=�6m   $��80��6�   ��5+      �� 5,      -   5        img_profileSource�� �� ImageSource$ img/twitter-logo-2-1.png��5,   D   5.      � 50      -   5        $ grd_Personal��50      $��
95,0,0,156q�61   .+�51      �� -   5        $ lbl_name��51       $��Nombre��62   $
��Left=�6C   $��10,6,0,5q�6^   $��Center=�6p   �� 52      -   5        $ 
lbl_tiempo��52       $��	Creación��64   $��Right=�6G   $��0,6,30,5q�6c   $��Center=�6u   53      �� 55      -   5        	 ��Name$	 lbl_text��55       $
��text��62   $
��Left=�6>   $��
105,44,0,0q�6Y   $	��Top=�6m   $	��464��6�   $	��146��6�   $
��Wrap=�6�   � 57      -   5        $ grd_Interacciones��57      $��10,95,479,5q�66   .+�58      �� -   5        $ img_verificado��58       $��10,7,0,0q�69   $��img/Verificado.png��6K   $��20��6g   $
��Left=�6r   $	��Top=�6�   �� 59      -   5        $ lbl_verificado��59       $��Verif��68   $
��Left=�6H   $��42,7,0,0q�6c   $	��Top=�6u   $��25��6�   �� 5;      -   5        $ lbl_like��5;       $
��like��62   $
��Left=�6A   $��	42,36,0,0q�6\   $	��Top=�6o   $��25��6�   �� 5<      -   5        $ img_like��5<       $
��Left=�62   $��20��6M   $��	10,39,0,0q�6Y   $	��Top=�6l   $��20��6�   $��img/Like.png��6�   �� 5>      -   5        $ lbl_rt��5>       $��rt��60   $
��Left=�6=   $��	42,68,0,0q�6X   $	��Top=�6k   $��25��6�   �� 5?      -   5        $ img_rt��5?       $
��Left=�60   $��20��6K   $��	10,71,0,0q�6W   $	��Top=�6j   $��20��6�   $��
img/rt.png��6�   5A      5C      5D      � 5F      -   5        $ 	grd_chart��5F      $��258,111,259,230q�6&   $��Center=�6?   $	��330��6\   .+�5G         LiveCharts.Wpf.PieChart  -   5        
  Name$
 
myPieChart��5G         StartingRotationAngle$ 0Q�63   $��	0,0,235,0q�6M   �� 5H      -   5        $ lbl_topLenguage��5H      $��Lenguaje mas utilizado: ��61   $
��Left=�6T   $��
100,10,0,0q�6o   $	��Top=�6�   �� 5I      -   5        $ lbl_porcentaje��5I      $��% respecto al total: ��60   $
��Left=�6P   $��
100,41,0,0q�6k   $	��Top=�6   5J      5L        5N   
   -   5          Name$ 	mdc_ayuda��5N      $��2q�61   $��0q�6=   $��Center=�6H   $��Center=�6e   $	��300��6�   $	��100��6�   $y�Hidden=�6�   .��5O      �� -   5        $	 	txb_ayuda��5O      $����En esta ventana encontrarás información sobre la actividad y el impacto en directo del treding seleccionado. La información mostrada es solo una aproximación, unicamente alrededor del 1% de tweets a nivel mundial son registrados��6+   $
��Left=�6  $	��Top=�62  $
��Wrap=�6J  $��	10,10,0,0q�6^  $	��280��6q  $��80��6}   �� TextAlignment$ Center=�6�  5P      5Q      5R      