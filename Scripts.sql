CREATE TABLE Company (
    id int PRIMARY KEY IDENTITY(1,1),
    Title varchar(255),
    Description varchar(500)
);

CREATE TABLE Position (
    id int PRIMARY KEY IDENTITY(1,1),
    Title varchar(256),
    Description varchar(500)
);

CREATE TABLE Departament (
    id int PRIMARY KEY IDENTITY(1,1),
    Title varchar(256),
    Description varchar(500)
);

CREATE TABLE Employee (
    id int PRIMARY KEY IDENTITY(1,1),
    FirstName varchar(255),
    LastName varchar(255),
    Patronymic varchar(255),
    Adress varchar(255),
    Phone varchar(255),
    BirthDay date,
    EntryDay date,
    Salary int,
    Departament_Id int,
    Position_Id int,
    Company_Id int,
    FOREIGN KEY (Departament_Id) REFERENCES Departament(id),
    FOREIGN KEY (Position_Id) REFERENCES Position(id),
    FOREIGN KEY (Company_Id) REFERENCES Company(id)
);


INSERT INTO Position (Title, Description)
VALUES ('Junior', 'Junior Description');

INSERT INTO Position (Title, Description)
VALUES ('Middle', 'Middle Description');

INSERT INTO Position (Title, Description)
VALUES ('Senior', 'Senior Description');

INSERT INTO Position (Title, Description)
VALUES ('TeamLead', 'TeamLead Description');

INSERT INTO Position (Title, Description)
VALUES ('PM', 'PM Description');




INSERT INTO Departament (Title, Description)
VALUES ('IT', 'IT departament description');

INSERT INTO Departament (Title, Description)
VALUES ('Sales', 'Sales departament description');

INSERT INTO Departament (Title, Description)
VALUES ('Marketing', 'Marketing departament description');

INSERT INTO Departament (Title, Description)
VALUES ('Technical support', 'Technical support departament description');



INSERT INTO Company (Title, Description)
VALUES ('GSC Game World', 'company description');

INSERT INTO Company (Title, Description)
VALUES ('A4 games', 'company description');

INSERT INTO Company (Title, Description)
VALUES ('Ubisoft', 'company description');


insert into Employee (FirstName, LastName, Patronymic, Adress, Phone, BirthDay, EntryDay, Salary, Departament_Id, Position_Id, Company_Id) 
values ('Elias', 'Dykins', null, '5561 Westridge Drive', '503-112-7412', '2004-11-27', '2023-04-01', 29875, 4, 1, 2);

insert into Employee (FirstName, LastName, Patronymic, Adress, Phone, BirthDay, EntryDay, Salary, Departament_Id, Position_Id, Company_Id) 
values ('Goldia', 'Prinn', null, '11 Golf View Junction', '705-407-9149', '2002-12-20', '2023-01-10', 46207, 2, 3, 3);

insert into Employee (FirstName, LastName, Patronymic, Adress, Phone, BirthDay, EntryDay, Salary, Departament_Id, Position_Id, Company_Id) 
values ('Felix', 'Bocke', null, '4722 Rieder Terrace', '708-380-2571', '2005-04-22', '2023-06-01', 26149, 3, 2, 2);

insert into Employee (FirstName, LastName, Patronymic, Adress, Phone, BirthDay, EntryDay, Salary, Departament_Id, Position_Id, Company_Id) 
values ('Jeannette', 'Eagles', null, '17222 Steensland Avenue', '945-115-1387', '2004-10-02', '2022-12-26', 44368, 4, 2, 1);

insert into Employee (FirstName, LastName, Patronymic, Adress, Phone, BirthDay, EntryDay, Salary, Departament_Id, Position_Id, Company_Id) 
values ('Lek', 'Craufurd', null, '51290 Grasskamp Park', '965-921-9608', '2004-01-14', '2023-05-25', 41591, 4, 1, 3);

insert into Employee (FirstName, LastName, Patronymic, Adress, Phone, BirthDay, EntryDay, Salary, Departament_Id, Position_Id, Company_Id) 
values ('Marne', 'Rumsey', null, '16380 Toban Junction', '118-429-6185', '2003-08-31', '2023-01-12', 28963, 2, 2, 3);

insert into Employee (FirstName, LastName, Patronymic, Adress, Phone, BirthDay, EntryDay, Salary, Departament_Id, Position_Id, Company_Id) 
values ('Leonardo', 'Hackley', null, '440 Superior Trail', '580-424-0178', '2005-08-25', '2023-03-06', 58006, 4, 5, 2);

insert into Employee (FirstName, LastName, Patronymic, Adress, Phone, BirthDay, EntryDay, Salary, Departament_Id, Position_Id, Company_Id) 
values ('Bancroft', 'Connah', null, '52636 Ronald Regan Point', '949-807-7165', '2005-03-03', '2023-10-22', 58363, 4, 3, 3);

insert into Employee (FirstName, LastName, Patronymic, Adress, Phone, BirthDay, EntryDay, Salary, Departament_Id, Position_Id, Company_Id) 
values ('Jennifer', 'Creavan', null, '6 Doe Crossing Circle', '709-518-4101', '2005-11-03', '2023-06-03', 45935, 2, 4, 2);

insert into Employee (FirstName, LastName, Patronymic, Adress, Phone, BirthDay, EntryDay, Salary, Departament_Id, Position_Id, Company_Id) 
values ('Jedediah', 'Rattrie', null, '3834 Shoshone Park', '669-311-4676', '2004-02-25', '2023-05-15', 54165, 1, 3, 2);

insert into Employee (FirstName, LastName, Patronymic, Adress, Phone, BirthDay, EntryDay, Salary, Departament_Id, Position_Id, Company_Id) 
values ('Jeanne', 'Rainger', null, '75 Bonner Place', '196-898-9659', '2005-09-14', '2023-09-13', 32491, 3, 4, 2);

insert into Employee (FirstName, LastName, Patronymic, Adress, Phone, BirthDay, EntryDay, Salary, Departament_Id, Position_Id, Company_Id) 
values ('Gleda', 'Leehane', null, '21187 Sunbrook Junction', '441-587-4094', '2005-11-13', '2023-01-31', 41531, 2, 5, 3);

insert into Employee (FirstName, LastName, Patronymic, Adress, Phone, BirthDay, EntryDay, Salary, Departament_Id, Position_Id, Company_Id)
values ('Aimee', 'Fripps', null, '410 Tomscot Hill', '639-419-9380', '2005-05-01', '2023-03-08', 56170, 1, 5, 3);

insert into Employee (FirstName, LastName, Patronymic, Adress, Phone, BirthDay, EntryDay, Salary, Departament_Id, Position_Id, Company_Id) 
values ('Daron', 'Lacky', null, '4 Grover Park', '127-550-6453', '2003-08-13', '2023-01-03', 20462, 3, 3, 1);

insert into Employee (FirstName, LastName, Patronymic, Adress, Phone, BirthDay, EntryDay, Salary, Departament_Id, Position_Id, Company_Id) 
values ('Ethelind', 'Cleen', null, '48471 Erie Road', '731-939-2890', '2004-07-31', '2023-08-25', 48346, 1, 2, 3);

