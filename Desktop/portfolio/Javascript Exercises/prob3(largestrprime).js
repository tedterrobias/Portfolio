/**
Problem from projecteuler.com
Problem # 3

The prime factors of 13195 are 5, 7, 13 and 29.

What is the largest prime factor of the number 600851475143 ?
*/

function largestPrime()
{
    let number = 600851475143;
    let largestPrimeFactor = 0;
    let factor = 2;

    while(number > 1)
    {
        if(number % factor === 0)
        {
            number /= factor;
            largestPrimeFactor = (largestPrimeFactor < factor) ? factor : largestPrimeFactor;
            factor = 2;
        }
        else factor++;
    }
    return largestPrimeFactor;
}

let lp = largestPrime();
console.log(lp);