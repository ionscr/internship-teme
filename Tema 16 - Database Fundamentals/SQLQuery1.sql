CREATE TABLE users (
    id INT PRIMARY KEY IDENTITY (1, 1),
    first_name VARCHAR (50) NOT NULL,
    last_name VARCHAR (50) NOT NULL,
);
CREATE TABLE class (
    id INT PRIMARY KEY IDENTITY (1, 1),
    class_name VARCHAR (50) NOT NULL,
    teacher_id INT NOT NULL,
	FOREIGN KEY (teacher_id) REFERENCES users(id) 
);
CREATE TABLE classroom (
    id INT PRIMARY KEY IDENTITY (1, 1),
    classroom_name VARCHAR (50) NOT NULL UNIQUE,
    classroom_location VARCHAR (50) NOT NULL,
	capacity INT DEFAULT 50
);
CREATE TABLE schedule (
    id INT PRIMARY KEY IDENTITY (1, 1),
    class_id INT NOT NULL,
    classroom_id INT NOT NULL,
	FOREIGN KEY (class_id) REFERENCES class(id),
	FOREIGN KEY (classroom_id) REFERENCES classroom(id)
);

INSERT INTO users (first_name, last_name) VALUES
('Mihai','Keo'), ('Andrei','Mercury'), ('Morcov','Roz'), ('Mar','Alb'), ('Opio','Rewo');

INSERT INTO class (class_name, teacher_id) VALUES
('POO', 1), ('WEB', 2), ('MAth', 2), ('Art', 3);

INSERT INTO classroom (classroom_name, classroom_location, capacity) VALUES
('508A','BLOC A',20), ('412A', 'BLOC A', 30), ('112C', 'BLOC C', 111);

INSERT INTO schedule (class_id, classroom_id) VALUES
(1,1), (2,1), (3,2), (4,3);

SELECT first_name as Nume, last_name as Prenume from users;

SELECT classroom_name as Sala from classroom where capacity > 25 and classroom_location like 'BLOC A';

SELECT u.last_name as Profesor, cl.classroom_name as Sala from users u inner join (SELECT class.teacher_id, s.classroom_name from class inner join (SELECT schedule.class_id, classroom.classroom_name from schedule inner join classroom on schedule.classroom_id = classroom.id) s on class.id = s.class_id) cl on u.id = cl.teacher_id;

SELECT u.last_name as Profesor from users u inner join (SELECT class.teacher_id, count(class.teacher_id) as cnt from class  group by class.teacher_id having count(class.teacher_id) > 1) l on u.id = l.teacher_id;

SELECT users.first_name from users ORDER BY users.last_name DESC;


