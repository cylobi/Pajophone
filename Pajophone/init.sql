CREATE DATABASE pajophone;
CREATE USER 'user'@'%' IDENTIFIED BY 'password';
GRANT ALL ON pajophone.* TO 'user'@'%';
FLUSH PRIVILEGES;