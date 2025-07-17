import style from "./ProductNavigation.module.css";

interface Props {
	pageNo: number;
	totalPages: number;
	itemsPerPage: number;
	onPageChange(page: number, itemsPerPage: number): void;
	onProdAdd(state: boolean): void;
}

export function ProductNavigation({pageNo, totalPages, itemsPerPage, onPageChange, onProdAdd} : Props) {
	
	function changeItemsPerChange(e: React.ChangeEvent<HTMLSelectElement>) {
		onPageChange(1, parseInt(e.target.value));
	}
	
	return(
		<div className={style.paginationContainer}>
			<div className={style.functionContainer}>
				<button onClick={() => onProdAdd(true)}>ADD PRODUCT</button>
			</div>
			<div className={style.paginationMain}>
				<button className={style.paginationBtn} onClick={() => onPageChange(pageNo-1, itemsPerPage)}>&#9664;</button>
				<div className={style.currentPage}>{pageNo}</div>
				{pageNo < totalPages ? <button className={style.paginationBtn} onClick={() => onPageChange(pageNo+1, itemsPerPage)}>&#9654;</button> : null}
				<select className={style.selectList} value={itemsPerPage} onChange={(e) => changeItemsPerChange(e)}>
					{[10, 25, 50].map((n) => (
						<option key={n} value={n}>
							{n} PER PAGE
						</option>
					))}
				</select>
			</div>
		</div>
	)
}