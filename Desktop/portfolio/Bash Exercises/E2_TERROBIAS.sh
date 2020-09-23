#--------------------------------------------------------------------------#
# Filename        : TERROBIAS_E2.sh                                        #
# Author          : Ted Terrobias                                          #        
# Last Modified   :  November 23, 2017                                     #
# Description     : Lab Excercise 2: Shell Control Structures              #
#   				This excercise exhibits use of conditional and 		   #
#					loop statements as well as access of command arguments #
# Honor Code      : This is my own program. I have not received any        #
#                   unauthorized help in completing this work. I have not  #
#                   copied from my classmate, friend, nor any unauthorized #
#                   resource. I am well aware of the policies stipulated   #
#                   in the handbook regarding academic dishonesty.         #     
#                   If proven guilty, I won't be credited any points for   #
#                   this exercise.                                         #
#--------------------------------------------------------------------------#

#!/bash/bin

#check for user's name to welcome 
if test -z "$1" # -z is true when length of string is 0
then
	echo "This script requires one argument. "
	exit
else
	echo "Welcome $1!"
fi

echo "Enter a counting number"
read num
	
sum=0	#set sum to 0 to for the exact amount of sum 
prod=1	#set prod to 0 to avoid 0 product
count_add=0	#set count to 1 to avoid 
count_prod=1	#set product counter to 1 to avoid 0 product
rem=0

if test $num -ge 0
then
	#loop for computing sum
	while test $count_add -le $num #use loop to go through every number from count to num
	do
		let rem=count_add%2	#compute for remainder
		
		if ((rem==0)) #if remainder = 0, then num is even
			then
				let sum=sum+count_add #add the even number to sum
				let count_add+=1 #increment count by 1
		else #number is odd
				let count_add+=1 #increment count by 1 
		fi
	done
	echo "The sum of even counting numbers up to $num is $sum."

	#loo for computing product
	while test $count_prod -le $num #use loop to go through every number from count to num
	do
		let rem=count_prod%2	#compute for remainder
		
		if ((rem==0)) #if remainder = 0, then num is even
			then
				let prod=prod*count_prod #add the even number to sum
				let count_prod+=1 #increment count by 1
		else #number is odd
				let count_prod+=1 #increment count by 1 
		fi
	done
	
	if ((num==0)) #since count_prod=1 and prod=1, when the input is 0, prod will be 1.
	then
		echo "The product of even counting numbers up to $num is 0."
	else
		echo "The product of even counting numbers up to $num is $prod."
	fi
	
elif test $num -lt 0 #if num is not a counting number
then
	echo "$num is not a counting number."
fi