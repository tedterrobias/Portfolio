/**
Problem from projecteuler.com
Problem # 1
If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.

Find the sum of all the multiples of 3 or 5 below 1000.

 * 
 */

function mutipleThreeAndFive()
{
    let sum = 0;
    for(let counter = 0; counter <= 1000; counter++)
    {
        if(counter % 3 === 0 || counter % 5 === 0) sum += counter;
    }
    return sum;
}

let sum = mutipleThreeAndFive();

console.log(sum);