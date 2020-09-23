/*Ted Terrobias
 * ICST201	N2
 * 6.28.2016
 * PROBLEM:
 * Letter grades are sometimes assigned to numeric scores by using the grading scheme com-
monly known as grading on the curve. In this scheme, a letter grade is assigned to a
numeric score according to the following table:
x = Numeric Score
x< m -
m -
3
2:cr
3
I
-cr
~ x < m - -cr
2
2
Letter Grade
F
D
C
B
m
+ ~cr~x
Here, m is the mean score and cr is the standard deviation; for a set of n numbers xb x2,' .. ,
X m
these are defined as follows (where
L
denotes the sum as i ranges from a to b):
i = 1
m
1 n
n i =l
= - ~Xi
a=
1 n
~ (Xi
n j = 1
-
-
m)
2
Write a program to read a list of real numbers representing numeric scores, call functions
to calculate their mean and standard deviation, and then call a function to determine and
display the letter grade corresponding to each numeric score.
* 
* ALGORITHM:
* 1. Declare int i, and int array rs with the size of i in int main().
* 2. Create class grade and declare int idx and int array raw_score with the size of idx privately.
* 3. Create constructor for class grade that receives the value of idx and the array raw_score.
* 4. Declare void function processValues().
* 5. In processValues(), declare int variables sum, sum_sd, double variables mean, mean_sd, standard_dev, and array temp.
* 6. In processValues(), compute for the mean by adding the sum of raw_score array and storing it to sum, then divide sum by idx 
* and store the quotient in mean.
* 7. In processValues(), compute for the standard deviation by subtracting the mean to each raw_score and square the result then 
* store the result in temp, get the mean of the values in temp and store it to mean_sd, then square mean_sd and store it to standard_dev.
* 8. In processValues(), identify the letter grade of each raw_score by using the formula provided in the problem.
 * */

#include <iostream>
#include <cmath>

using namespace std;

class grade
{
	private:
	int idx;
	int raw_score[];

	public:
	grade(int i, int rs[])
	{
		idx = i;
		for(int a = 0; a < idx; a++)
			raw_score[a] = *(rs + a);
	}
		
	void processValues()
	{
		int sum = 0, sum_sd = 0;
		double mean, mean_sd, standard_dev;
		double temp_sd[idx];
		
		//mean
		for(int a = 0; a < idx; a++)
		{
			sum += raw_score[a];
		}
		
		mean = sum / idx;
		
		//standard deviation
		
		for(int a = 0; a < idx; a++)
		{
			temp_sd[a] = pow(raw_score[a]-mean, 2);
		}
		
		for(int a = 0; a < idx; a++)
		{
			sum_sd += temp_sd[a];
		}
		
		mean_sd = sum_sd / idx;
		standard_dev = sqrt(mean_sd);
		
		/*
		cout << sum << endl;
		cout << mean << endl;
		cout << sum_sd << endl;
		cout << mean_sd << endl;
		cout << standard_dev << endl;
		*/
		
		//letter grade
		for(int a = 0; a < idx; a++)
		{
			if(raw_score[a] < mean - (1.5 * standard_dev))
			{
				cout << raw_score[a] << "\t" << "F" << endl;
			}
			else if(raw_score[a] >= mean - (1.5 * standard_dev) && raw_score[a] < mean - (0.5 * standard_dev))
			{
				cout << raw_score[a] << "\t" << "D" << endl;
			}
			else if(raw_score[a] >= mean - (0.5 * standard_dev) && raw_score[a] < mean + (0.5 * standard_dev))
			{
				cout << raw_score[a] << "\t" << "C" << endl;
			}
			else if(raw_score[a] >= mean + (0.5 * standard_dev) && raw_score[a] < mean + (1.5 * standard_dev))
			{
				cout << raw_score[a] << "\t" << "B" << endl;
			}
			else if(raw_score[a] >= mean + (1.5 * standard_dev))
			{
				cout << raw_score[a] << "\t" << "A" << endl;
			}
		}
	}
};

int main()
{
	int i;
	do{
		cout << "How many scores would you like to be calculated? : ";
		cin >> i;
		if(i <= 0)
		{
			cout << "please enter a number greater than 0. " << endl;
		}
	}while(i <= 0);
	
	int rs[i];

	for(int a = 0; a < i; a++)
	{
		cout << "Enter grade: ";
		cin >> rs[a];
	}

	grade grade1(i,rs);
	grade1.processValues();

	return 0;
}
