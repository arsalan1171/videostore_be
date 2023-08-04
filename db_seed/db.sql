--seed Customers into DB
INSERT INTO Customer (Name, Address, PhoneNumber)
VALUES ('John Doe', '123 Main Street', '555-123-4567');

INSERT INTO Customer (Name, Address, PhoneNumber)
VALUES ('Jane Smith', '456 Park Avenue', '555-987-6543');

INSERT INTO Customer (Name, Address, PhoneNumber)
VALUES ('Robert Johnson', '789 Elm Road', '555-456-7890');

INSERT INTO Customer (Name, Address, PhoneNumber)
VALUES ('Alice Brown', '987 Oak Lane', '555-567-8901');

INSERT INTO Customer (Name, Address, PhoneNumber)
VALUES ('Michael Lee', '321 Cedar Drive', '555-234-5678');

INSERT INTO Customer (Name, Address, PhoneNumber)
VALUES ('Emily Wang', '567 Pine Street', '555-678-9012');

INSERT INTO Customer (Name, Address, PhoneNumber)
VALUES ('David Kim', '345 Maple Avenue', '555-345-6789');

INSERT INTO Customer (Name, Address, PhoneNumber)
VALUES ('Sarah Wilson', '789 Birch Road', '555-890-1234');

INSERT INTO Customer (Name, Address, PhoneNumber)
VALUES ('Daniel Chen', '123 Spruce Lane', '555-901-2345');

INSERT INTO Customer (Name, Address, PhoneNumber)
VALUES ('Jennifer Garcia', '456 Willow Street', '555-456-7890');


--seed videos into DB
INSERT INTO Videos (Title, Description, RentalPrice,  NumberOfCopies)
VALUES
  ('Introduction to Artificial Intelligence', 'Learn the fundamentals of AI.', 19.99, 5),
  ('Web Development for Beginners', 'A comprehensive course for web development.', 24.99,  10),
  ('Python Programming Masterclass', 'Master Python programming.', 29.99,  8),
  ('Data Science with R', 'Explore data analysis using R.', 22.50,  12),
  ('Android App Development: From Beginner to Pro', 'Build Android apps from scratch.', 1.99,  3),
  ('Digital Marketing Strategies', 'Effective digital marketing techniques.', 18.75,  7),
  ('Photography Basics', 'Learn the basics of photography.', 14.99,  6),
  ('JavaScript Fundamentals', 'Core concepts of JavaScript.', 27.50,  9),
  ('Machine Learning Essentials', 'Key concepts and algorithms of ML.', 31.25,  11),
  ('UI/UX Design Principles', 'Master the principles of UI/UX design.', 2.99,  4);

