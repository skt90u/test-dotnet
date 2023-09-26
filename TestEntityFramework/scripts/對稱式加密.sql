
-- use AdventureWorks2022;
-- use AdventureWorks2019;

-- step 01. 建立對稱金鑰
-- drop symmetric key mykey;

create symmetric key my_key
with algorithm = AES_256, key_source = 'my_key_source',
identity_value = 'my_key_identity'
encryption by password = 'my_password';

-- step 02. 查詢對稱金鑰
select * from sys.symmetric_keys;

-- step 03. 變更對稱金鑰密碼
/*
open  symmetric key my_key decryption      by password = 'my_password';
alter symmetric key my_key add encryption  by password = 'my_new_password'; -- 新增新密碼
close symmetric key my_key;

open  symmetric key my_key decryption      by password = 'my_new_password';
alter symmetric key my_key drop encryption by password = 'my_new_password'; -- 刪除舊密碼
close symmetric key my_key;
*/

-- step 04. 加解密測試
open  symmetric key my_key decryption     by password = 'my_password';
select convert(nvarchar(1000), decryptbykey(encryptbykey(key_guid('my_key'), convert(nvarchar(1000), N'ABC'))));
close symmetric key my_key;

-- drop table my_table;
-- step 00. 建立加密資料表
create table my_table (
	id int identity(1, 1) not null,
	my_data varbinary(max) null
);

-- step 05. 欄位加密
open  symmetric key my_key decryption      by password = 'my_password';
insert into my_table(my_data) values (encryptbykey(key_guid('my_key'), convert(nvarchar(1000), N'ABC')));
close symmetric key my_key;


-- step 06. 欄位解密
open  symmetric key my_key decryption     by password = 'my_password';
select id, my_data as my_data1, convert(nvarchar(1000), decryptbykey(my_data)) as my_data2 from my_table;
close symmetric key my_key;

