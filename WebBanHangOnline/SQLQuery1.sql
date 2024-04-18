Create proc sp_ThongKe
as 
BEGIN
DECLARE @SoTruyCapGanNhat int
DECLARE @Count int
SELECT @Count= COUNT(*) FROM ThongKes
IF @Count IS NULL SET @Count=0
IF @Count = 0
INSERT INTO ThongKes(ThoiGian,SoTruyCap)
Values(GETDATE(),1)
ELSE
BEGIN
DECLARE @ThoiGianGanNhat datetime
SELECT @SoTruyCapGanNhat = tk.SoTruyCap, @ThoiGianGanNhat= tk.ThoiGian FROM ThongKes tk
WHERE tk.Id =( SELECT MAX(tk1.id) FROM ThongKes tk1)
IF @SoTruyCapGanNhat IS NULL SET @SoTruyCapGanNhat=0
IF @ThoiGianGanNhat IS NULL SET @ThoiGianGanNhat = GETDATE()

-- nếu chưa chuyển sang ngày mới thì update
IF DAY(@ThoiGianGanNhat)= DAY(GETDATE())
	BEGIN
		UPDATE ThongKes
		SET
		SoTruyCap= @SoTruyCapGanNhat +1,
		ThoiGian= GETDATE()
		WHERE id=(SELECT id FROM ThongKes tk1)
END
-- Nếu đã chuyển sang ngày mới rồi thì thêm 1 bản ghi mới
ELSE
INSERT INTO ThongKes(ThoiGian, SoTruyCap)
Values(GETDATE(),1)

END
-- Thống kê hôm nay, hôm qua, Tuàn này, Tuần Trước, Tháng này, Tháng Trước
DECLARE @HomNay int
SET @HomNay= DATEPART(DW, GETDATE());
SELECT @SoTruyCapGanNhat= SoTruyCap, @ThoiGianGanNhat= ThoiGian FROM ThongKes 
WHERE id=(SELECT MAX(id) FROM ThongKes)

-- số truy cập ngày hôm qua
DECLARE @TruyCapHomQua bigint

SELECT @TruyCapHomQua=ISNULL(SoTruyCap,0) FROM ThongKes 
WHERE CONVERT(nvarchar(20),ThoiGian,103)= CONVERT(nvarchar(20),GETDATE()-1,103)
IF @TruyCapHomQua IS NULL SET @TruyCapHomQua=0
--truy cập đầu tuần này
DECLARE @DauTuanNay datetime
SET @DauTuanNay= DATEADD(wk, DATEDIFF(wk,6,GetDate()),6)
-- Tính ngày đầu tuần trước
DECLARE @NgayDauTuanTruoc datetime
SET @NgayDauTuanTruoc = Cast(CONVERT(nvarchar(30),DATEADD(dd, -(@HomNay +6), GetDate()),101)AS datetime)
-- Tính ngày  cuối tuần trước đến 24h ngày cuối tuần

DECLARE @NgayCuoiTuanTruoc  datetime
SET @NgayCuoiTuanTruoc=  Cast(CONVERT(nvarchar(30),DATEADD(dd, -@HomNay, GetDate()),101) + ' 23:59:59' AS datetime)
-- Số truy cập tuần này
	DECLARE @TruyCapTuanNay bigint
	SELECT @TruyCapTuanNay = ISNULL(SUM(SoTruyCap),0) FROM ThongKes
	WHERE ThoiGian BETWEEN @DauTuanNay AND GETDATE()
-- Số truy cập tuần trước
	DECLARE @SoLanTruyCapTuanTruoc bigint
	SELECT @SoLanTruyCapTuanTruoc = ISNULL(SUM(SoTruyCap),0) FROM ThongKes ttk

	WHERE ttk.ThoiGian BETWEEN @NgayDauTuanTruoc AND @NgayCuoiTuanTruoc
-- Số truy cập tháng này
	DECLARE @SoTruyCapThangNay bigint
	SELECT @SoTruyCapThangNay = ISNULL(SUM(SoTruyCap),0) 
	FROM ThongKes ttk Where MONTH(ttk.ThoiGian)= MONTH(GETDATE())
	
-- Số truy cập tháng trước
	DECLARE @SoTruyCapThangTruoc bigint
	SELECT @SoTruyCapThangTruoc = ISNULL(SUM(SoTruyCap),0) 
	FROM ThongKes ttk Where MONTH(ttk.ThoiGian)= MONTH(GETDATE())-1
	--Tính tổng số
	DECLARE @TongSo bigint
	SELECT @TongSo = ISNULL(SUM(SoTruyCap),0) FROM ThongKes ttk
	SELECT @SoTruyCapGanNhat AS Homnay,
	@TruyCapTuanNay AS TuanNay,
	@SoLanTruyCapTuanTruoc AS TuanNay,
	@SoTruyCapThangNay AS ThangNay,
	@SoTruyCapThangTruoc AS ThangTruoc,
	@TongSo AS TatCa
END