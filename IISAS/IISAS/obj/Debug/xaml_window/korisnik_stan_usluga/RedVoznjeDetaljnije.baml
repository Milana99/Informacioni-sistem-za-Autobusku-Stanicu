   M S B A M L   `   `   `  ����@  <IISAS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:IISAS.xaml_window.korisnik_stan_usluga&IISAS.xaml_window.korisnik_stan_usluga  5   	   @    :IISAS.xaml_window.korisnik_stan_usluga.RedVoznjeDetaljnije   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Flocal4clr-namespace:IISAS.xaml_window.korisnik_stan_usluga     5   	     � Title$  RedVoznjeDetaljnije��5   	   $	��450��6%   $	��600��62    � WindowStartupLocation$ CenterScreen=�6>   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��100 �6   �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $	��140 �6   6-   �� 5      $��* �6   6+   �� 5      $	��110 �6   6-   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $	��120 �6   6-   ��5   
   �� 5       �� ImageSource$F @slike\Slidebooks Consulting _ Business & Consulting Toolkits.jpg��6    j� Stretch$ UniformToFill=�6l    �� Opacity$	 0.9Q�6�   .+�5   
   �� $��0��6   $��2��6   $��4��6.   $��6��6B   ���	#FF1D3045$��3q�6k   $��20,20,20,60q�6�   ._�5      �� $��0��6   $��5��6&    �� Orientation$ Vertical=�6:   ��5       �� 5!       �� Color$ 	#FFE0E9F3��6&   $	 0.9Q�68   .+�5#      �� $ Vertical=�6   $��2��64   $��0��6D   $��4��6Q   $��
20, 60,0,0q�6e   $��5��6y   .+�5$      �� $ 
Horizontal=�6!   .+�5%      �� $
��Bold"�6    $��	20,0,70,0q�63   .��6F   Početna stanica:6X   �� 5&      -   5        $��lbPocetnaStanica��5&   !   .��69   Početna stanica6J   5'      5(      �� 5)      $ Vertical=�6   $��2��64   $��0��6D   $��4��6Q   $��	20, 0,0,0q�6e   $��5��6x   .+�5*      �� $ 
Horizontal=�6!   .+�5+      �� $
��Bold"�6    $��	20,0,75,0q�63   .��6F   Krajnja stanica:6X   �� 5,      -   5        $��lbKrajnjaStanica��5,   !   .��69   Krajnja stanica6J   5-      5.      �� 5/      $ Vertical=�6   $��2��64   $��0��6D   $��4��6Q   $��	20, 0,0,0q�6e   $��5��6x   .+�50      �� $ 
Horizontal=�6!   .+�51      �� $
��Bold"�6    $��
20,0,100,0q�63   .��6G   
Prevoznik:6S   �� 52      -   5        $��lbPrevoznik��52   !   .��64   	Prevoznik6?   53      54      �� 55      $ Vertical=�6   $��2��64   $��0��6D   $��4��6Q   $��	20, 0,0,0q�6e   $��5��6x   .+�56      �� $ 
Horizontal=�6!   .+�57      �� $
��Bold"�6    $��
20,0,117,0q�63   .��6G   Datum:6O   �� 58      -   5        $��lbDatum��58   !   .��60   
16/06/20226<   59      5:      �� 5;      $ Vertical=�6   $��2��64   $��0��6D   $��4��6Q   $��	20, 0,0,0q�6e   $��5��6x   .+�5<      �� $ 
Horizontal=�6!   .+�5=      �� $
��Bold"�6    $��	20,0,73,0q�63   .��6F   Vreme polaska:6V   �� 5>      -   5        $��lbVremePolaska��5>   !   .��67   
16:00:006A   5?      5@      �� 5A      $ Vertical=�6   $��2��64   $��0��6D   $��4��6Q   $��	20, 0,0,0q�6e   $��5��6x   .+�5B      �� $ 
Horizontal=�6!   .+�5C      �� $
��Bold"�6    $��	20,0,73,0q�63   .��6F   Vreme dolaska:6V   �� 5D      -   5        $��lbVremeDolaska��5D   !   .��67   
18:00:006A   5E      5F      �� 5H      $ Vertical=�6   $��2��64   $��0��6D   $��4��6Q   $��	20, 0,0,0q�6e   $��5��6x   .+�5I      �� $ 
Horizontal=�6!   .+�5J      �� $
��Bold"�6    $��	20,0,40,0q�63   .��6F   Preko(Autoput/Sela):6\   �� 5K      -   5        $��lbPreko��5K   !   .��60   Sela66   5L      5M      �� 5N      $ Vertical=�6   $��2��64   $��0��6D   $��4��6Q   $��	20, 0,0,0q�6e   $��5��6x   .+�5O      �� $ 
Horizontal=�6!   .+�5P      �� $
��Bold"�6    $��
20,0,124,0q�63   .��6G   Peron:6O   �� 5Q      -   5        $��lbPeron��5Q   !   .��60   Peron67   5R      5S      �� 5T      $ Vertical=�6   $��2��64   $��0��6D   $��4��6Q   $��	20, 0,0,0q�6e   $��5��6x   .+�5U      �� $ 
Horizontal=�6!   .+�5V      �� $
��Bold"�6    $��	20,0,61,0q�63   .��6F   Preostalih karata:6Z   �� 5W      -	   5        $��lbPreostalihKarata��5W       .��6:   166>   5X      5Y      5Z      5\      �� 5^   
   $��2��6   $��4��6    $��Center=�64   $��Center=�6Q   $��30(�6l   .��6z   Red vožnje6�   �� 5a   
   -
   5        $��3��5a      $��5��6!   $��3��6.   $��Right=�6B   $	��120��6^   $��40��6j   ���	#FFEDEDED
���   �$��0,0,20,0q�6�   $��15(�6�   ���	#FF4D4D4D$��1,1,2,2q�6�   .��5b      �� $ 
Horizontal=�6   .+�5c      �� $��20(�6   ���	#FFEDEDED
���   �$��Segoe MDL2 Assets)�6P   $	����6o   $��0,0,0,0q�6�   6�   �� 5d      
���   �$��15(�6+   .��69   Izađi6@   5e      5f      �� 5h   
   $��5��6   $ 
Horizontal=�6"   .+�5i      �� $��40��6   $��40��6    $��2,0,0,0q�6,   $��0��6=   ��5j      �� 5k      $&  slike\rocketship-303591_1280.png��6!   $	 0.4Q�6P   5n      �� 5o      $��SemiBold"�6   $��Center=�6*   $��20(�6E   $��	Castellar)�6S   ��5p      �� 5q      $ 	#FFE0E9F3��6&   $	 0.5Q�68   ��5s      �� 5t      $ Transparent��6&   $	 0.3Q�6:   .��5u   $   RaKeta5v      5w      5y      5z      