import type { Category } from "../models/objectTypes";
import { useState, useEffect } from 'react';
import { CategoryItem } from "../components/CategoryItem/CategoryItem";

export function Category() {
	const [categories, setCategories] = useState<Category[]>([]);

	const API_PATH = "https://localhost:7047/api"

	useEffect(() => {
		getCategoryList();
	}, []);

	async function getCategoryList() {
		const url = `${API_PATH}/categories`;
		
		try {
			const resp = await fetch(url, {
				method: "GET",
				headers: {'Accept': 'application/json'}
			});

			if (resp.ok) {
				const data = await resp.json();

				if (data && data.length > 0) {
					setCategories(data);
				}
			}
		} catch {
			console.log("Error. Could not get product list");
		}
	}

	return(
		<div>
			{categories.length > 0 ? categories.map((c) => (
				<CategoryItem category={c}/>
			)) : <p>No categories found</p>}
		</div>
	)
}