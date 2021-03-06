/*TERROBIAS, TED N.
 * ICST214	N3
 * 12.7.2015
 * POLLING
 * 7.38 - Java How to Program
 * 
 * PROBLEM:
 * Making a Difference
7.38 (Polling) The Internet and the web are enabling more people to network, join a cause, voice
opinions, and so on. The presidential candidates in 2008 used the Internet intensively to get out
their messages and raise money for their campaigns. In this exercise, you’ll write a simple polling
program that allows users to rate five social-consciousness issues from 1 (least important) to 10
(most important). Pick five causes that are important to you (e.g., political issues, global environ-
mental issues). Use a one-dimensional array topics (of type String ) to store the five causes. To sum-
marize the survey responses, use a 5-row, 10-column two-dimensional array responses (of type
int ), each row corresponding to an element in the topics array. When the program runs, it should
ask the user to rate each issue. Have your friends and family respond to the survey. Then have the
program display a summary of the results, including:
a) A tabular report with the five topics down the left side and the 10 ratings across the top,
listing in each column the number of ratings received for each topic.
b) To the right of each row, show the average of the ratings for that issue.
c) Which issue received the highest point total? Display both the issue and the point total.
d) Which issue received the lowest point total? Display both the issue and the point total.

ADDITIONAL: Display on file. (File Processing)
* 
* ALGORITHM:
* 1. Import all necessary packages to be used in the program.
* 2. Declare the String array for the issues, declare the integer array for the issue_vote, declare the double array for the average
* number of votes for each issue, and the integer array for the total number of votes per issue.
* 3. Display the five issues to the user using for loop.
* 4. Ask for the users vote for each of the issue using for loop. each issue will be rated from 1-10. if the rating is less than 1 and
* greater than 10. the user will be asked again to rate the same issue.
* 5. Declare a static void method that will write the results in an external file. Use Filewriter and for loop to output the results
* in the separate file. Display the issues on the separate file.
* 6. Declare a static void method that will display the results on the program. Use for loop to display the results.
* 7. Declare a static void method that will display the issues that had the highest and the lowest points. Use for loop and
* if statement to get the issues with the highest and lowest point.
* 8. Call the methods declared in numbers 5, 6 and 7.
*/

import java.util.Scanner;
import java.io.*;
import java.util.*;

class Terrobias_E5
{
public static void main(String args[])throws IOException
{
	String issue [] = {"Terrorism issues","Global Racial issues","LGBT Community issues","Environmental issues","Corruption issues"};
	
	int issue_vote [][] = new int [5][10];
	
	double ave_votes_issue [] = {0,0,0,0,0};
	int total_votes_issue [] = {0,0,0,0,0};
	
	Scanner input = new Scanner(System.in);
	


for(int a = 0; a < 5; a++)
{
	System.out.println("["+(a+1)+"]"+issue[a]);
}

System.out.println();

for(int voter = 0; voter < 10; voter++)
{
	for(int issues = 0; issues < 5; issues++)
	{
		System.out.print("Voter #"+(voter+1)+" enter your rating for issue #"+(issues+1)+": ");
		issue_vote [issues][voter] = input.nextInt();
		while(issue_vote [issues][voter] > 10 | issue_vote [issues][voter] < 1)
		{
			System.out.print("between 1 - 10 only: ");
			issue_vote [issues][voter]= input.nextInt();
		}
	}
	System.out.println();
}

//total & ave votes per issue 
for(int issues = 0; issues < 5; issues++)
{
	for(int voter = 0; voter < 10; voter++)
	{
		total_votes_issue[issues] += issue_vote[issues][voter];
	}
	ave_votes_issue[issues] = (double) total_votes_issue[issues] / 10.0;
}

writeVotes(issue,issue_vote,"Terrobias_E5.out");

System.out.println();
System.out.println();

displayResults(issue,issue_vote,ave_votes_issue);
dispHighestLowest(issue,total_votes_issue);

System.exit(0);
}

//write results in file
static void writeVotes(String issue_array[], int vote_array[][], String file_directory)throws IOException
{
	int counter = 1;
	FileWriter outFile = new FileWriter(file_directory);
	for(int a = 0; a < 5; a++)
	{
		outFile.write("["+counter+"]"+issue_array[a]+"\n");
		counter++;
	}
	
	counter = 1;
	
	for(int a = 0; a < 5; a++)
	{
	outFile.write("["+counter+"]"+"\t");
		counter++;
		for(int b = 0; b < 10; b++)
		{
			outFile.write(vote_array[a][b] + "\t");
		}
		outFile.write("\n");
	}
	outFile.close();
}

static void displayResults(String issue_array[], int vote_array[][], double ave_votes_issue[])
{
	System.out.print("Voter's #\t\t");
	for(int title = 0; title < 11; title++)
	{
		if(title < 10)
		{
			System.out.print("#"+(title+1)+"\t");
		}
		else
		{
			System.out.print("AVERAGES");
		}
	}
	System.out.println();
	for(int issue = 0; issue < 5; issue++)
	{
		System.out.print(issue_array[issue]+"\t");
		for(int voter = 0; voter < 10; voter++)
		{
			System.out.print(vote_array[issue][voter]+"\t");
		}
		System.out.print(ave_votes_issue[issue]);
		System.out.println();
	}
}

static void dispHighestLowest(String issue_array[], int total_votes_issue[])
{
	int max = total_votes_issue[0];
	int min = total_votes_issue[0];
	int max_key = 0;
	int min_key = 0;
	
	//find max
	for(int a = 0; a < 5; a++)
	{
		if(max < total_votes_issue[a])
		{
			max = total_votes_issue[a];
			max_key = a;
		}
	}
	
	for(int a = 0; a < 5; a++)
	{
		if(min > total_votes_issue[a])
		{
			min = total_votes_issue[a];
			min_key = a;
		}
	}
	
	System.out.print("Highest point total: "+issue_array[max_key]+" "+max+" points.\n");
	System.out.print("Lowest point total: "+issue_array[min_key]+" "+min+" points.\n");
}
}
