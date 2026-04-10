Employee Annual Performance Bonus Calculation System
🎯 Background
A multinational organization calculates employee annual performance bonuses using a rule-based system. The bonus depends on multiple factors including performance rating, years of experience, attendance percentage, department multiplier, and progressive tax deduction rules.
Your task is to implement a C# class with a calculated property that computes the employee’s final net annual bonus according to the business rules defined below.
The property must contain the complete calculation logic (no external service class).
Students will then write unit tests using NUnit to validate all scenarios.

🧱 Requirements
Create a class named:
public class EmployeeBonus

🧮 Calculated Property
Create a read-only property:
public decimal NetAnnualBonus { get; }
This property must compute the bonus using the following rules.

📊 Business Rules
Step 1: Base Bonus Percentage (Based on Rating)

If rating is outside 1–5, throw InvalidOperationException.

Step 2: Experience Bonus
Additional percentage applied on BaseSalary:
More than 10 years → +5%
More than 5 years → +3%
Otherwise → No additional bonus

Step 3: Attendance Penalty
If AttendancePercentage < 85%, reduce current bonus by 20%.

Step 4: Department Multiplier
Multiply bonus by DepartmentMultiplier.

Step 5: Maximum Cap
The total bonus before tax must not exceed:
40% of BaseSalary
If exceeded, cap it to 40%.

Step 6: Tax Deduction
Apply tax on bonus (after cap):

Step 7: Final Output
Return:
Final Bonus after tax
Rounded to 2 decimal places using:
Math.Round(value, 2)

⚠ Edge Case Handling
If BaseSalary ≤ 0 → Return 0.
Invalid rating → Throw exception.
Attendance can be 0–100 only (optional validation).

🧪 Testing Requirements (Using NUnit)
Students must write comprehensive unit tests covering:
1️⃣ Normal Calculation Case
Valid rating, no penalties, no cap triggered.
2️⃣ Experience Bonus Trigger
Test both:
5 years
10 years
3️⃣ Attendance Penalty
Attendance < 85%.
4️⃣ Cap Rule
Create salary scenario where calculated bonus exceeds 40%.
5️⃣ All Tax Slabs
Test:
10% slab
20% slab
30% slab
6️⃣ Invalid Rating Test
Verify exception is thrown.
7️⃣ Zero Salary Case
Bonus must return 0.
8️⃣ Precision Test
Verify rounding behavior for long decimal values.

✅ Test Case 1 – Normal High Performer (No Cap Triggered)
Input

✅ Expected Output
123200.00

✅ Test Case 2 – Attendance Penalty Applied
Input

✅ Expected Output
60480.00

✅ Test Case 3 – Cap Triggered
Input

✅ Expected Output
280000.00
✅ Test Case 4 – Zero Salary
Input
BaseSalary = 0
Expected Output
0.00
✅ Test Case 5 – Low Performer (Rating 2)
Input

✅ Expected Output
13500.00

✅ Test Case 6 – Exact 150,000 Tax Boundary
Input

✅ Expected Output
64800.00

✅ Test Case 7 – High Tax Slab (>300k Without Cap)
Input

✅ Expected Output
226800.00

✅ Test Case 8 – Rounding Precision Case
Input

✅ Expected Output
118649.88
