CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';




CREATE TABLE IF NOT EXISTS keeps(
  id int NOT NULL primary key  AUTO_INCREMENT comment 'Primary Key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP comment 'Create Time',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP  comment 'Updated At',
  creatorId VARCHAR(255) NOT NULL comment 'FK: Account Id',
  name VARCHAR(255) NOT NULL comment 'Keep Name',
  description VARCHAR(255) NOT NULL comment 'Keep Description',
  img VARCHAR(255) NOT NULL comment 'img url',
  views int NOT NULL default 0 comment 'keep views',
  shares int NOT NULL default 0 comment 'keep shares',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
)  default charset utf8 comment '';

