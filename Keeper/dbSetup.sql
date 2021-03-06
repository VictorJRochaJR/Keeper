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
  keeps int NOT NULL DEFAULT 0 comment 'keeps',
  views int NOT NULL default 0 comment 'keep views',
  shares int NOT NULL default 0 comment 'keep shares',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
)  default charset utf8 comment '';


CREATE TABLE IF NOT EXISTS vaults(
  id int NOT NULL primary key AUTO_INCREMENT comment 'Primary Key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP comment 'Created At',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP comment 'Updated At',
  creatorId VARCHAR(255) NOT NULL comment 'FK: Account Id',
  name VARCHAR(255) NOT NULL comment 'Vault Name',
  description VARCHAR(255) NOT NULL comment 'Vault Description',
  isPrivate TINYINT NOT NULL comment "Private Vault",
  FOREIGN KEY(creatorId) references accounts(id) ON DELETE CASCADE
)   default charset utf8 comment '';

CREATE TABLE IF NOT EXISTS vaultkeeps(
  id int NOT NULL PRIMARY KEY AUTO_INCREMENT comment 'Primary Key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP comment 'Created At',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP comment 'Updated At',
  creatorId VARCHAR(255) NOT NULL comment 'FK: Account Id',
  vaultId int comment 'FK: Vault Id',
  keepId int comment 'FK: Keep Id',
  FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY(vaultId) REFERENCES vaults(id) ON DELETE CASCADE,
  FOREIGN KEY(keepId) REFERENCES keeps(id) ON DELETE CASCADE
) default charset utf8 comment '';




SELECT k.*,
 a.* 
 FROM keeps k
 JOIN accounts a ON k.creatorId = a.id
 WHERE k.id = @id;


 Alter TABLE vaults
ADD description varchar(255);