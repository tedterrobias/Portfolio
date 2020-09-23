/*
#--------------------------------------------------------------------------#
# Filename        : E5_Terrobias.c                                         #
# Author          : Ted Terrobias                                          #        
# Last Modified   : December 12, 2017                                      #
# Description     : Lab Exercise No. 5 - Tally Board			           #
#					Tallying a set of test scores into 10 predefined       #
# 					classes        						  				   #
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

struct Scores
{
	int val;
	scores *next;
};

int main()
{
	int caserun;
	int casecount = 1;
	
	//ask for number of cases
	printf("Enter number of cases: "); 
	scanf(" %i", &caserun);
	
	//if caserun > 50, ask again.
	while(caserun > 50)
	{
		printf("number of cases must be <= 50 \n");
		printf("Enter number of cases: "); 
		scanf(" %i", &caserun);
	}
	
	//declare *score
	struct Scores *score;
	
	//scan line for scores and store in val 
	/*while(scanf(" %i", &score->val) != NULL)
	{
		score
	}*/
	
	//tallying
	while(casecount <= caserun)
	{
		printf("CASE %d:\n", casecount);
		
		//...
		
		casecount++;
	}
	
	return 0;
}
