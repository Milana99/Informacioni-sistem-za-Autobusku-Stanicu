   M S B A M L   `   `   `  ����@  <IISAS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:IISAS.xaml_window.korisnik_stan_usluga&IISAS.xaml_window.korisnik_stan_usluga  5   	   T    NIISAS.xaml_window.korisnik_stan_usluga.Pregeld_rezervisanih_karata_obavestenje   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Flocal4clr-namespace:IISAS.xaml_window.korisnik_stan_usluga     5   	     � Title$  Raketa��5       � Icon$ slike\space.ico��6    $	��450��67   $	��500��6D    � WindowStartupLocation$ CenterScreen=�6P   $	��450��6u   $	��500��6�   .��5	      � ���	#FF153B64 � RowDefinitions 5
   
   �� 5      $	��100 �6   �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $	��140 �6   6-   �� 5      $��* �6   6+   �� 5      $	��110 �6   6-   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $	��120 �6   6-   .+�5   
   �� $��0��6   $��2��6!   $��0��65   $��2��6B    J� RenderTransformOrigin$ 0.5,0.5&�6S   ��5      �� 5       �� ImageSource$H Bslike\_Pngtree_blue technology sense abstract floating_5439768.png��6    j� Stretch$ UniformToFill=�6n    j� TileMode$ FlipY=�6�   	 �� Opacity$	 1Q�6�   
 �� RelativeTransform
 5      V� 5      .~�5       ��  �� ScaleY$ 1Q�6-    �� ScaleX$ -1Q�68   �� 5!       �� AngleY$ 0Q�6,    �� AngleX$ 0Q�67   �� 5"       �� Angle$ 0Q�6.   T� 5#      5$      5&      5(      �� 5*   
   $��3��6   $��3��6!   $��3��65   $��3��6B   $ 0.5,0.5&�6S   ��5+      �� 5,      $H Bslike\_Pngtree_blue technology sense abstract floating_5439768.png��6   $ UniformToFill=�6n   $ FlipY=�6�   $	 1Q�6�   
 5-      V� 5.      .~�5/      �� $ 1Q�6-   $ -1Q�68   �� 50      $ 0Q�6,   $ 0Q�67   �� 51      $ 0Q�6.   T� 52      53      55      57      �� 59   
   $��0��6   $��0��6   $��6��6/   $	��350��6C   $��6��6O   ���	#FF1D3045$��0q�6x   $��	0,20,0,60q�6�   ._�5:      �� $��0��6   $��5��6&    �� Orientation$ Vertical=�6:   ��5;      �� 5<       �� Color$ 	#FFE0E9F3��6&   $		 0.9Q�68   .+�5>      �� $ Vertical=�6   $��2��64   $��0��6D   $��4��6Q   $��
20, 90,0,0q�6e   $��5��6y   .+�5?      �� $ 
Horizontal=�6!   5@      �� 5A      $ Vertical=�6   $��2��64   $��0��6D   $��4��6Q   $��0,40,0,0q�6e   $��5��6w   .+�5B      �� $ 
Horizontal=�6!   5C      5E      5F      �� 5H   
   $��1��6   $��4��6    $��Center=�64   $��Center=�6Q   $��30(�6l   .��6z   Obaveštenja6�   �� 5J   
   $��5��6   $��0��6"   $��Center=�62   $��6��6P   $ 
Horizontal=�6d   .+�5L      �� -   5        $	��120��5L      $��40��6!   ���	#FFEDEDED
���   �$��	0,10,20,0q�6W   $��15(�6j   ���	#FF4D4D4D$��1,1,2,2q�6�   .��5M      �� $ 
Horizontal=�6   .+�5N      �� $��20(�6   ���	#FFEDEDED
���   �$��Segoe MDL2 Assets)�6T   $	����6s   $��0,0,0,0q�6�   6�   �� 5O      
���   �$��15(�6/   .��6=   Izađi6D   5P      5Q      5R      �� 5S   
   $��1��6   $��4��6"   $��0��63   $��6��6C   $��100,0,100,0q�6W   .+�5T      �� -   5        $��lvDataBinding��5T      $��
0, 0, 0, 0q�6,   $	��230��6A   ���	#FF001B62��5U      �� 5V      $ 	#FFFAFAFB��6&   $		 0.9Q�68    �� View 5X      �� 5Y      .P�5Z      �� $��Poruka��6)    �� Width$
 Auto��69    �� DisplayMemberBinding 6F   �� *poruka+6p   �� 5[      $��Polazna stanica��6)   $
 Auto��6B    6O   �� *voznja.polazna_stan.naz_stan+6�   �� 5\      $��Krajnja stanica��6)   $
 Auto��6B    6O   �� *voznja.krajnja_stan.naz_stan+6�   �� 5]      $��	Prevoznik��6*   $
 Auto��6=    6J   �� *$"voznja.autobus.autoprev.naziv_prev+6�   �� 5^      $��Datum��6*   $
 Auto��69    6F   �� *voznja.datum+6v   �� 5_      $��Polazak��6)   $
 Auto��6j    6:   �� *voznja.pol_sat+6y   �� 5`      $��Dolazak��6)   $
 Auto��6j    6:   �� *voznja.dol_sat+6y   5b      5d      5e      5h      5i      