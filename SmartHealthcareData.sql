-- 新建数据库
create database SmartHealthcareData

-- 新建直播表
create table tb_sys_live
(
	liveid							int primary key auto_increment,		-- 直播id
	room_id							varchar(100),											-- 直播间id
	live_title					varchar(100),											-- 直播标题
	live_statrtime			date,															-- 直播开始时间
	live_endtime				date,															-- 直播结束时间
	live_img						varchar(100),											-- 直播封面图
	live_state					int,															-- 直播状态
	UserId							int,															-- 用户id
	creationtime				date,															-- 创建时间
	modificationtime		date,															-- 修改时间
	deletetime					date,															-- 删除时间
	creationperson			varchar(20),											-- 创建人
	modificationperson	varchar(20),											-- 修改人
	deleteperson				varchar(20)												-- 删除人
)

-- 新建直播聊天室
create table tb_sys_livechat
(
	livechatid		int primary key auto_increment,		-- 聊天室id
	user_id				int,															-- 用户id
	send_time			date,															-- 发生时间
	chat_message	varchar(200)											-- 发送信息
)

-- 新建直播记录表
create table tb_sys_liverecord
(
	liverecordid				int primary key auto_increment,		-- 直播记录id
	record_peonumber		int,															-- 在线人数
	see_people					varchar(50),											-- 观看用户
	live_statrtime			date,															-- 直播开始时间
	live_endtime				date,															-- 直播结束时间
	room_id							int,															-- 直播间id
	live_title					varchar(100)											-- 直播标题
	creationtime				date,															-- 创建时间
	modificationtime		date,															-- 修改时间
	deletetime					date,															-- 删除时间
	creationperson			varchar(20),											-- 创建人
	modificationperson	varchar(20),											-- 修改人
	deleteperson				varchar(20)												-- 删除人
)

-- 新建用户信息表
create table tb_sys_userinfo
(
	userid							int primary key auto_increment,		-- 用户id
	username						varchar(10),											-- 用户姓名
	useradmin						varchar(20),											-- 用户登录账号
	userpass						varchar(20),											-- 用户登录密码
	userage							int,															-- 用户年龄
	usersex							int,										 					-- 用户性别
	useridcard					varchar(18),											-- 用户身份证号
	userphone						varchar(11),											-- 用户手机号
	userdeletestate			int,															-- 用户状态(逻辑删除)
	usernumber					varchar(50),											-- 用户编号
	useravatar					varchar(100),											-- 用户头像
	userhobby						varchar(100),											-- 用户爱好
	userbalance					decimal(7,2),										  -- 用户余额
	useraddress					varchar(100),											-- 用户地址
	creationtime				date,															-- 创建时间
	modificationtime		date,															-- 修改时间
	deletetime					date,															-- 删除时间
	creationperson			varchar(20),											-- 创建人
	modificationperson	varchar(20),											-- 修改人
	deleteperson				varchar(20)												-- 删除人
)

select userid,username,useradmin,userpass,userage,usersex,useridcard,userphone,userdeletestate,usernumber,useravatar,userhobby,userbalance,useraddress,creationtime,modificationtime,deletetime,creationperson,modificationperson,deleteperson from tb_sys_userinfo where userphone = '' or username = ''

insert into tb_sys_userinfo (userid,username,useradmin,userpass	,userage,usersex,useridcard,userphone,userdeletestate,usernumber,useravatar,userhobby,userbalance,useraddress,creationtime,modificationtime,deletetime,creationperson,modificationperson,deleteperson) values (null,'杨宇坤','2862547662','123456',20,1,'130435202020202020','17732072862',0,'user_2003_0005','','睡觉',34.27,'河北邯郸',CURRENT_TIMESTAMP,null,null,'杨宇坤','','')

select userid,username,useradmin,userpass	,userage,usersex,useridcard,userphone,userdeletestate,usernumber,useravatar,userhobby,userbalance,useraddress,creationtime,modificationtime,deletetime,creationperson,modificationperson,deleteperson from tb_sys_userinfo


select userid,username,useradmin,userpass,userage,usersex,useridcard,userphone,userdeletestate,usernumber,useravatar,userhobby,userbalance,useraddress,creationtime,modificationtime,deletetime,creationperson,modificationperson,deleteperson from tb_sys_userinfo where useradmin = '2862547662' and userpass = '123456'

-- 新建角色信息表
create table tb_sys_roleinfo
(
	roleid							int primary key auto_increment,		-- 角色id
	rolename						varchar(10),											-- 角色姓名
	creationtime				date,															-- 创建时间
	modificationtime		date,															-- 修改时间
	deletetime					date,															-- 删除时间
	creationperson			varchar(20),											-- 创建人
	modificationperson	varchar(20),											-- 修改人
	deleteperson				varchar(20)												-- 删除人
)

-- 新建用户角色表
create table tb_sys_userrole
(
	userid							int,															-- 用户id
	roleid							int 															-- 角色id
)

select userid,roleid,creationtime,modificationtime,deletetime,creationperson,modificationperson,deleteperson from tb_sys_userrole
insert into tb_sys_userrole (userid,roleid,creationtime,modificationtime,deletetime,creationperson,modificationperson,deleteperson) values (1,1,now(),null,null,'杨宇坤','','')

-- 新建医院表
create table tb_sys_Hospital
(
	hospitalid					int primary key auto_increment,		-- 医院id
	hospitalname				varchar(10),											-- 医院名称
	hospitalcode				varchar(30),											-- 医院编码
	hospitalpid					int,															-- 医院父级id
	creationtime				date,															-- 创建时间
	modificationtime		date,															-- 修改时间
	deletetime					date,															-- 删除时间
	creationperson			varchar(20),											-- 创建人
	modificationperson	varchar(20),											-- 修改人
	deleteperson				varchar(20)												-- 删除人
)

-- 新建医生信息表
create table tb_sys_DoctorInfo
(
	Doctorid						int primary key auto_increment,   -- 医生id
	Doctorname					varchar(10),											-- 医生姓名
	hospitalid					int,															-- 所属医院
	physicianid					int,											        -- 医生职称
	userphone						varchar(11),											-- 手机号
	useridcardimg				varchar(100),											-- 身份证照片
	certificateimg			varchar(100),											-- 医师资格证
	professionalimg			varchar(100),											-- 医师执业证书
	hospitalcode				varchar(30),											-- 所属科室
	creationtime				date,															-- 创建时间
	modificationtime		date,															-- 修改时间
	deletetime					date,															-- 删除时间
	creationperson			varchar(20),											-- 创建人
	modificationperson	varchar(20),											-- 修改人
	deleteperson				varchar(20)												-- 删除人
)

-- 新建医生职称表
create table tb_sys_Physiciantitle
(
	physicianid			int primary key auto_increment,	-- 医生职称id
	physicianname 	varchar(10)											-- 医生职称名称
)

-- 新建商品信息表
create table Tb_sys_GoodsInfo
(
	GoodsId							int primary key auto_increment,	-- 商品id
	GoodsName						varchar(20),										-- 商品名称
	GoodsPrice					decimal(2),										  -- 商品价格
	GoodsIsState				int,														-- 是否有货
	GoodsShelfState			int,														-- 上下架
	GoodsDeleteState		int,														-- 是否删除
	GoodsNumber					int,														-- 存货数量
	GoodsImg						varchar(100),										-- 商品图片
	ProductID						varchar(20),										-- 商品编码
	GoodsDescription		varchar(100),										-- 商品简介
	GoodsSpecification	varchar(20),										-- 商品规格
	GoodsServe					varchar(100),										-- 售后服务
	TypeId							int,														-- 类别id
	CreationTime				date,														-- 创建时间
	ModificationTime		date,														-- 修改时间
	Deletetime					date,														-- 删除时间
	CreationPerson			varchar(20),										-- 创建人
	ModificationPerson	varchar(20),										-- 修改人
	DeletePerson				varchar(20)											-- 删除人
)

select a.GoodsId,a.GoodsName,a.GoodsPrice,a.GoodsIsState,a.GoodsShelfState,a.GoodsDeleteState,a.GoodsNumber,a.GoodsImg,a.ProductID,a.GoodsDescription,a.GoodsSpecification,a.GoodsServe,a.TypeId,a.CreationTime,a.ModificationTime,a.Deletetime,a.CreationPerson,a.ModificationPerson,a.DeletePerson,b.TypeName from Tb_sys_GoodsInfo a join tb_sys_GoodsType b on a.TypeId = b.TypeId

select a.GoodsId,a.GoodsName,a.GoodsPrice,a.GoodsIsState,a.GoodsShelfState,a.GoodsDeleteState,a.GoodsNumber,a.GoodsImg,a.ProductID,a.GoodsDescription,a.GoodsSpecification,a.GoodsServe,a.TypeId,a.CreationTime,a.ModificationTime,a.Deletetime,a.CreationPerson,a.ModificationPerson,a.DeletePerson,b.TypeName from Tb_sys_GoodsInfo a join tb_sys_GoodsType b on a.TypeId = b.TypeId where a.GoodsDeleteState = 0

select GoodsId,GoodsName,GoodsPrice,GoodsIsState,GoodsShelfState,GoodsDeleteState,GoodsNumber,GoodsImg,ProductID,GoodsDescription,GoodsSpecification,GoodsServe,TypeId,CreationTime,ModificationTime,Deletetime,CreationPerson,ModificationPerson,DeletePerson from tb_sys_goodsinfo where GoodsDeleteState = 0

select GoodsId,GoodsName,GoodsPrice,GoodsIsState,GoodsShelfState,GoodsDeleteState,GoodsNumber,GoodsImg,ProductID,GoodsDescription,GoodsSpecification,GoodsServe,TypeId,CreationTime,ModificationTime,Deletetime,CreationPerson,ModificationPerson,DeletePerson from tb_sys_Goodsinfo

insert into tb_sys_goodsingo (GoodsId,GoodsName,GoodsPrice,GoodsIsState,GoodsShelfState,GoodsDeleteState,GoodsNumber,GoodsImg,ProductID,GoodsDescription,GoodsSpecification,GoodsServe,TypeId,CreationTime,ModificationTime,Deletetime,CreationPerson,ModificationPerson,DeletePerson) values (null,@name,@price,@isstate,@shelfstate,@delstate,@number,@img,@ductid,@iption,@fication,@serve,@tid,@addtime,@upttime,@deltime,@addren,@uptren,@delren)

-- 新建商品类别表
create table Tb_sys_GoodsType
(
	TypeId							int primary key auto_increment,	-- 类别id
	TypeName						varchar(20),										-- 类别名称
	GoodsTypeNumber			int,														-- 类别商品剩余数量
	CreationTime				date,														-- 创建时间
	ModificationTime		date,														-- 修改时间
	Deletetime					date,														-- 删除时间
	CreationPerson			varchar(20),										-- 创建人
	ModificationPerson	varchar(20),										-- 修改人
	DeletePerson				varchar(20)											-- 删除人
);

select TypeId,TypeName,GoodsTypeNumber,CreationTime,ModificationTime,Deletetime,CreationPerson,ModificationPerson,DeletePerson from Tb_sys_GoodsType
insert into Tb_sys_GoodsType (TypeId,TypeName,GoodsTypeNumber,CreationTime,ModificationTime,Deletetime,CreationPerson,ModificationPerson,DeletePerson) values (null,'呼吸',1494,NOW(),null,null,'杨宇坤','','');
insert into Tb_sys_GoodsType (TypeId,TypeName,GoodsTypeNumber,CreationTime,ModificationTime,Deletetime,CreationPerson,ModificationPerson,DeletePerson) values (null,'锻炼',1234,NOW(),null,null,'杨宇坤','','');
insert into Tb_sys_GoodsType (TypeId,TypeName,GoodsTypeNumber,CreationTime,ModificationTime,Deletetime,CreationPerson,ModificationPerson,DeletePerson) values (null,'心脏',1124,NOW(),null,null,'杨宇坤','','');
insert into Tb_sys_GoodsType (TypeId,TypeName,GoodsTypeNumber,CreationTime,ModificationTime,Deletetime,CreationPerson,ModificationPerson,DeletePerson) values (null,'脉搏',1434,NOW(),null,null,'杨宇坤','','');
insert into Tb_sys_GoodsType (TypeId,TypeName,GoodsTypeNumber,CreationTime,ModificationTime,Deletetime,CreationPerson,ModificationPerson,DeletePerson) values (null,'养生',1764,NOW(),null,null,'杨宇坤','','');
insert into Tb_sys_GoodsType (TypeId,TypeName,GoodsTypeNumber,CreationTime,ModificationTime,Deletetime,CreationPerson,ModificationPerson,DeletePerson) values (null,'按摩',1764,NOW(),null,null,'杨宇坤','','');

https://6bj3594361.zicp.fun/202211141858538858.jpg
-- 新建药品表
create table Tb_sys_Pharmaceuticals
(
	drug_id								int primary key auto_increment,		-- 药品id
	drug_coding						varchar(100),											-- 药品编码
	drug_name							varchar(20),											-- 药品名称
	drug_img							varchar(100),											-- 药品图片
	drug_price						decimal(2),												-- 药品价格
	drug_state						int,															-- 药品状态
	drug_type							int,															-- 药品分类
	drug_specifications  	varchar(20),											-- 药品规格
	prescription					int,															-- 是否处方
	drug_repertory				int,															-- 库存数量
	drug_introduce				varchar(50)												-- 药品介绍
	CreationTime					date,															-- 创建时间
	ModificationTime			date,															-- 修改时间
	Deletetime						date,															-- 删除时间
	CreationPerson				varchar(20),											-- 创建人
	ModificationPerson		varchar(20),											-- 修改人
	DeletePerson					varchar(20)												-- 删除人		
)

-- 新建药品分类表
create table Tb_sys_PharmaceuType
(
	drug_type_id					int primary key auto_increment,		-- 药品分类id
	drug_type_name				varchar(50),											-- 药品分类名称
	drug_type_state				int,															-- 药品分类上下架状态
	drug_type_img					varchar(100),											-- 药品分类图片
	drug_type_repertory		int,															-- 该分类所剩库存
	CreationTime					date,															-- 创建时间
	ModificationTime			date,															-- 修改时间
	Deletetime						date,															-- 删除时间
	CreationPerson				varchar(20),											-- 创建人
	ModificationPerson		varchar(20),											-- 修改人
	DeletePerson					varchar(20)												-- 删除人	
)

-- 新建物流公司表
create table Tb_sys_LogisticsCompani
(
	logistics_company_id		int primary key auto_increment,		-- 物流公司id
	logistics_company_name	varchar(20),											-- 物流公司名称
	CreationTime						date,															-- 创建时间
	ModificationTime				date,															-- 修改时间
	Deletetime							date,															-- 删除时间
	CreationPerson					varchar(20),											-- 创建人
	ModificationPerson			varchar(20),											-- 修改人
	DeletePerson						varchar(20)												-- 删除人	
)

-- 新建商品订单表
create table Tb_sys_GoodsOrders
(
	drug_indent_id				int primary key auto_increment,		-- 商品订单id
	indent_number					varchar(20),											-- 商品订单编号
	User_id								int,															-- 用户id
	total_money						decimal(2),												-- 总金额
	actually_paid			 		decimal(2),												-- 实付金额
	indent_state			  	int,															-- 订单状态
	payment_state 				int,															-- 支付状态
	deliver_state 				int,															-- 发货状态
	take_deliver_state		int,															-- 收获状态
	CreationTime					date,															-- 创建时间
	ModificationTime			date,															-- 修改时间
	Deletetime						date,															-- 删除时间
	CreationPerson				varchar(20),											-- 创建人
	ModificationPerson		varchar(20),											-- 修改人
	DeletePerson					varchar(20)												-- 删除人
)

-- 新建商品订单详情表
create table Tb_sys_GoodsOrderDeta
(
	indent_mark						int	primary key auto_increment,		-- 订单号
	payment_number				varchar(50),											-- 支付编号
	User_id								int,															-- 用户Id
	commodity_number			int,															-- 商品购买数量
	logistics_company			int,															-- 物流公司
	express_number				varchar(100),											-- 快递单号
	distribution_type			decimal(2),												-- 配送费用
	distribution_remark		varchar(50),											-- 发货单备注
	drug_name							varchar(20),											-- 药品名称
	drug_img							varchar(100),											-- 药品图片
	drug_price						decimal(2),												-- 药品价格
	total_money						decimal(2),												-- 总金额
	actually_paid					decimal(2),												-- 实付金额
	CreationTime					date,															-- 创建时间
	ModificationTime			date,															-- 修改时间
	Deletetime						date,															-- 删除时间
	CreationPerson				varchar(20),											-- 创建人
	ModificationPerson		varchar(20),											-- 修改人
	DeletePerson					varchar(20)												-- 删除人
)

-- 新建秒杀活动表
create table Tb_sys_Commod_seckill
(
	indent_mark						int primary key auto_increment, 	-- 秒杀活动id
	payment_number				varchar(50),											-- 秒杀活动名称
	User_id								date,															-- 秒杀活动开始时间
	commodity_number			date,															-- 秒杀活动结束时间
	logistics_company			int,															-- 秒杀活动状态
	express_number				int,															-- 排序
	CreationTime					date,															-- 创建时间
	ModificationTime			date,															-- 修改时间
	Deletetime						date,															-- 删除时间
	CreationPerson				varchar(20),											-- 创建人
	ModificationPerson		varchar(20),											-- 修改人
	DeletePerson					varchar(20)												-- 删除人
)

-- 新建秒杀商品表
create table Tb_sys_Commod_Goods
(
	Commod_GoodsId			int	primary key auto_increment,   -- 秒杀商品id
	SeckillId						int,															-- 秒杀活动id
	GoodsId							int,															-- 商品id
	SeckillPrice				decimal(2),												-- 秒杀时价格
	GoodsName						varchar(20),											-- 商品名称
	GoodsImg						varchar(100),											-- 商品图片
	GoodsNumber					int,															-- 商品数量
	GoodsPrice					decimal(2),												-- 商品价格
	CreationTime				date,															-- 创建时间
	ModificationTime		date,															-- 修改时间
	Deletetime					date,															-- 删除时间
	CreationPerson			varchar(20),											-- 创建人
	ModificationPerson	varchar(20),											-- 修改人
	DeletePerson				varchar(20)												-- 删除人
)
















































































