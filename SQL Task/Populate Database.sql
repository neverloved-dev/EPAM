INSERT INTO Person (FirstName, LastName)
VALUES
    ('John', 'Doe'),
    ('Jane', 'Smith'),
    ('Michael', 'Johnson'),
    ('Emily', 'Williams'),
    ('David', 'Brown'),
    ('Sarah', 'Miller'),
    ('Robert', 'Wilson'),
    ('Jennifer', 'Jones'),
    ('William', 'Davis'),
    ('Linda', 'Martinez');

-- Insert 10 random addresses into the Address table
INSERT INTO Address (Street, City, State, ZipCode)
VALUES
    ('123 Main St', 'New York', 'NY', '10001'),
    ('456 Elm St', 'Los Angeles', 'CA', '90001'),
    ('789 Oak Ave', 'Chicago', 'IL', '60601'),
    ('101 Pine Rd', 'Houston', 'TX', '77001'),
    ('234 Maple Ln', 'Miami', 'FL', '33101'),
    ('567 Birch Dr', 'San Francisco', 'CA', '94101'),
    ('890 Cedar Pl', 'Boston', 'MA', '02101'),
    ('111 Spruce Ct', 'Philadelphia', 'PA', '19101'),
    ('222 Willow Way', 'Seattle', 'WA', '98101'),
    ('333 Sycamore Cir', 'Atlanta', 'GA', '30301');


-- Call 1
EXEC InsertEmployeeInfo
    @FirstName = 'John',
    @LastName = 'Doe',
    @CompanyName = 'Company1',
    @Street = '123 Main St',
    @City = 'New York',
    @State = 'NY',
    @ZipCode = '10001';

-- Call 2
EXEC InsertEmployeeInfo
    @FirstName = 'Jane',
    @LastName = 'Smith',
    @CompanyName = 'Company2',
    @Street = '456 Elm St',
    @City = 'Los Angeles',
    @State = 'CA',
    @ZipCode = '90001';

-- Call 3
EXEC InsertEmployeeInfo
    @FirstName = 'Michael',
    @LastName = 'Johnson',
    @CompanyName = 'Company3',
    @Street = '789 Oak Ave',
    @City = 'Chicago',
    @State = 'IL',
    @ZipCode = '60601';

-- Call 4
EXEC InsertEmployeeInfo
    @FirstName = 'Emily',
    @LastName = 'Williams',
    @CompanyName = 'Company4',
    @Street = '101 Pine Rd',
    @City = 'Houston',
    @State = 'TX',
    @ZipCode = '77001';

-- Call 5
EXEC InsertEmployeeInfo
    @FirstName = 'David',
    @LastName = 'Brown',
    @CompanyName = 'Company5',
    @Street = '234 Maple Ln',
    @City = 'Miami',
    @State = 'FL',
    @ZipCode = '33101';

-- Call 6
EXEC InsertEmployeeInfo
    @FirstName = 'Sarah',
    @LastName = 'Miller',
    @CompanyName = 'Company6',
    @Street = '567 Birch Dr',
    @City = 'San Francisco',
    @State = 'CA',
    @ZipCode = '94101';

-- Call 7
EXEC InsertEmployeeInfo
    @FirstName = 'Robert',
    @LastName = 'Wilson',
    @CompanyName = 'Company7',
    @Street = '890 Cedar Pl',
    @City = 'Boston',
    @State = 'MA',
    @ZipCode = '02101';

-- Call 8
EXEC InsertEmployeeInfo
    @FirstName = 'Jennifer',
    @LastName = 'Jones',
    @CompanyName = 'Company8',
    @Street = '111 Spruce Ct',
    @City = 'Philadelphia',
    @State = 'PA',
    @ZipCode = '19101';

-- Call 9
EXEC InsertEmployeeInfo
    @FirstName = 'William',
    @LastName = 'Davis',
    @CompanyName = 'Company9',
    @Street = '222 Willow Way',
    @City = 'Seattle',
    @State = 'WA',
    @ZipCode = '98101';

-- Call 10
EXEC InsertEmployeeInfo
    @FirstName = 'Linda',
    @LastName = 'Martinez',
    @CompanyName = 'Company10',
    @Street = '333 Sycamore Cir',
    @City = 'Atlanta',
    @State = 'GA',
    @ZipCode = '30301';
