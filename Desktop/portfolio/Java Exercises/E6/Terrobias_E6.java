/*
 * TERROBIAS, TED N.
 * ICST214	N3
 * 2.1.16
 * Text Analysis
 * 16.18 - Java How to Program
 * PROBLEM:
 * 16.18 (Text Analysis) The availability of computers with string-manipulation capabilities has re-
sulted in some rather interesting approaches to analyzing the writings of great authors. Much atten-
tion has been focused on whether William Shakespeare ever lived. Some scholars believe there’s
substantial evidence indicating that Christopher Marlowe actually penned the masterpieces attrib-
uted to Shakespeare. Researchers have used computers to find similarities in the writings of these
two authors. This exercise examines three methods for analyzing texts with a computer.
a) Write an application that reads a line of text from the keyboard and prints a table indi-
cating the number of occurrences of each letter of the alphabet in the text. For example,
the phrase
To be, or not to be: that is the question:
contains one “a,” two “b’s,” no “c’s,” and so on.
b) Write an application that reads a line of text and prints a table indicating the number
of one-letter words, two-letter words, three-letter words, and so on, appearing in the
text.
c) Write an application that reads a line of text and prints a table indicating the number of
occurrences of each different word in the text. The application should include the words
in the table in the same order in which they appear in the text. For example, the lines
To be, or not to be: that is the question:
Whether 'tis nobler in the mind to suffer
contain the word “to” three times, the word “be” two times, the word “or” once, etc. 
* ALGORITHM:
* 
* */

//"%-10s %-45s %s\n"

import java.util.Scanner;

class Terrobias_E6
{
public static void main(String [] args)
{	
	Scanner input = new Scanner(System.in);
	
	String str_a;
	String str_b;
	String str_c;
	
	Terrobias_E6B E6B;
	Terrobias_E6C E6C;
	
	System.out.println("Part A of E6\n");
	//A
	System.out.println("Enter a sentence then press enter.");
	str_a = input.nextLine();
	System.out.printf("The sentence is: \n%s\n",str_a);
	
	Terrobias_E6A E6A = new Terrobias_E6A(str_a);
	E6A.charCounter(str_a);
	
}
}
