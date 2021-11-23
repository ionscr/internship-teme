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

SELECT teacher_id as teacherId, count(class.id) as NumarClase from class group by teacher_id;
SELECT u.last_name as Profesor from users u inner join (SELECT class.teacher_id, count(class.teacher_id) as cnt from class  group by class.teacher_id having count(class.teacher_id) > 1) l on u.id = l.teacher_id;

CREATE TABLE users2 (
    id INT PRIMARY KEY IDENTITY (1, 1),
    first_name VARCHAR (50) NOT NULL,
    last_name VARCHAR (50) NOT NULL,
);

SET IDENTITY_INSERT users2 ON;
INSERT INTO users2 (id, first_name, last_name) SELECT id,first_name,last_name from users where first_name not like 'Morcov';
SET IDENTITY_INSERT users2 OFF;

--TRUNCATE TABLE users2;

DELETE u from users2 u inner join class c on u.id = c.teacher_id where u.id != 1;  

UPDATE 
	users
SET
	last_name = CONCAT('DR. ', last_name)
FROM
	users u 
	inner join class c
		ON u.id = c.teacher_id;


SELECT first_name,
       last_name,
       (SELECT Count(class.id)
        FROM   class
               INNER JOIN users
                       ON class.teacher_id = users.id
        GROUP  BY teacher_id
        HAVING teacher_id = (SELECT Avg(id)
                             FROM   users))
FROM   users
WHERE  last_name IN (SELECT last_name
                     FROM   users
                     WHERE  last_name LIKE 'DR.%');

SELECT classroom_location,
       capacity,
       CASE classroom_location
         WHEN 'BLOC A' THEN capacity + 20
         WHEN 'BLOC C' THEN capacity + 10
         ELSE capacity
       end AS new_capacity
FROM   classroom; 
