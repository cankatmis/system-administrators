# system-administrators
An application which determines the safe and unsafe time intervals for
the company based on the administrators holidays.

A small financial company hired two system administrators Alice and Bob. When an admin
wants to go to holiday in the next N days he or she have to tell the first and the last day of his
vacation. We call a time interval safe if both Alice and Bob are available for the company.
Similarly, we call a time interval unsafe if both admins are on their holiday.
The file holidays.in contains the vacation data of the administrators. The first line of this
file is N, the number of days to forecast (N < 1000). The next line contains the number of days
K that Alice will spend on holiday (K≤N). The following K lines are the first and last days of
Alice’s holidays separated by a semicolon. The next line contains the number of days L that
Bob will spends on holiday (L≤N). The rest of the lines are the first and last days of Bob’s
holidays separated by a whitespace.
The file holidays.out should start with the number of safe intervals S. The following S
lines should consist of a starting and ending day of a safe interval. After that, the number of
unsafe intervals U and finally the starting and ending days of unsafe intervals should be
placed.

Example:

holidays.in
50
3
5;10
40;45
15;20
1
12;24

holidays.out
4
1;4
11;11
25;39
46;50
1
15;20
