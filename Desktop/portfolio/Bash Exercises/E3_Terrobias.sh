#--------------------------------------------------------------------------#
# Filename        : E3_Terrobias.sh                                        #
# Author          : Ted Terrobias                                          #        
# Last Modified   : November 28, 2017                                      #
# Description     : Lab Exercise No. 3 - Shell Control Structures 2		   #
#					computing for area of the following: rectangle, square,#
#					triangle.											   #
# Honor Code      : This is my own program. I have not received any        #
#                   unauthorized help in completing this work. I have not  #
#                   copied from my classmate, friend, nor any unauthorized #
#                   resource. I am well aware of the policies stipulated   #
#                   in the handbook regarding academic dishonesty.         #     
#                   If proven guilty, I won't be credited any points for   #
#                   this exercise.                                         #
#--------------------------------------------------------------------------#

#!/bash/bin
clear

#Area of a Rectangle = length * width
#Area of a Circle = pi * radius^2
#Area of a Triangle = (base * height) / 2
#*for pi, use the value 3.1416

#In this program, the user will first choose a number from 1 to 9. 
#For options 1 to 3 rectangle; 
#options 4 to 6 circle; 
#and options 7 to 9  triangle.


choice="y"

while [ "$choice" != "n" ]
do
	read -p "Enter a number from 1 to 9: " opt
	
	if [[ $opt -ge 1 && $opt -le 3 ]] #rectangle
	then

		read -p "Enter length: " len #ask for length
		read -p "Enter width: " wid #ask for width

		let aRec=len*wid #compute for area of rectangle
		
		echo "The area of the rectangle is $aRec."

	elif [[ $opt -ge 4 && $opt -le 6 ]] #circle
	then
		read -p "Enter radius: " radi
		
		#let aCirc=3.1416(radi*radi) ERROR
		
		#aCirc="scale=4; 3.1416*($radi*$radi)" | bc ERROR

		echo "The area of the circle is $aCirc."
		
	elif [[ $opt -ge 5 && $opt -le 9 ]] #triangle
	then
		read -p "Enter base: " base #ask for base
		read -p "Enter height: " hgt #ask for height
		
		let aTri=(base*hgt)/2
		
		echo "The area of the triangle is $aTri."
	else
		echo "Incorrect input."
	fi
	
	#ask to run again
	read -p "Again? [y/n]: " choice
	
	if [[ "$choice" == *"n"* ]]
	 then
		clear
		exit
	fi	
done

