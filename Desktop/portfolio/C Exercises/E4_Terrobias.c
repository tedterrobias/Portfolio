/*
#--------------------------------------------------------------------------#
# Filename        : E4_Terrobias.sh                                        #
# Author          : Ted Terrobias                                          #        
# Last Modified   : December 12, 2017                                      #
# Description     : Lab Exercise No. 4 - Triangles			     		   #
#					displaying a triangle with dimensions according to     #
#                   user inputs         						  		   #
# Honor Code      : This is my own program. I have not received any        #
#                   unauthorized help in completing this work. I have not  #
#                   copied from my classmate, friend, nor any unauthorized #
#                   resource. I am well aware of the policies stipulated   #
#                   in the handbook regarding academic dishonesty.         #     
#                   If proven guilty, I won't be credited any points for   #
#                   this exercise.                                         #
#--------------------------------------------------------------------------#
*/

#include <stdio.h>

int main()
{
	char cho;
	int counter = 1;
	int tri = 0;
	int numcase;
	int counterb = 0; //array counter

	do //loop for program
	{
		//scan for number of cases
		scanf(" %i", &numcase);
		
		//set size of array to number of cases
		int num[numcase];
		char ascode[numcase];
		
		//loop for scanning input
		for(int a = 0; a < numcase; a++)
		{
			scanf(" %i %c", &num[a], &ascode[a]);
		}
		
		printf("\n");
		
		//loop for cases 
		while(counterb < numcase)
		{
			printf("CASE %d:\n", counter);
			
			//loop per row
			for(int row = 1; row <= num[counterb]; row++) 
			{
				//loop for space
				//decrement space 
				for(int space = 1; space <= num[counterb] - row; space++)
				{
					printf(" ");
				}
				
				//loop for tringle
				while(tri < (row*2)-1)
				{
					printf("%c", ascode[counterb]); //print ascode
					tri++; //next COLUMN
				}
				
				tri = 0;
				printf("\n"); //next row	
			}
			
			counterb++; //increment to next case
			printf("\n");
			counter++;
		}

		printf("Again? [y/n]:");
		scanf(" %c", &cho);
		
		//reset counters if ever the user wants to run the program again
		counter = 1;
		counterb = 0;
		
	}while(cho == 'y' && cho != 'n');
	return 0;	
}
