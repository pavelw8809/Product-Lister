import React, { useState, useEffect } from "react";
import type { Product } from "../models/ObjectTypes"

import { ProductItem } from "../components/ProductItem";

export function Main() {
    const [search, setSearch] = useState("");
    const [products, setProducts] = useState<Product[]>([]);
    const [pageSize, setPageSize] = useState<number>(10);
    const [pageNo, setPageNo] = useState<number>(1);

    const API_PATH = "https://localhost:7047/api"

    useEffect(() => {
        getProductList();
    }, [])

    async function getProductList(keyword?: string | null) {
        let url;

        if (keyword == null || keyword.length == 0) {
            url = `${API_PATH}/products?page=${pageNo}&pagesize=${pageSize}`
        } else {
            url = `${API_PATH}/products?name=${keyword}&page=${pageNo}&pagesize=${pageSize}`
        }

        try {
            const resp = await fetch(url, {
                method: 'GET', 
                headers: {'Accept': 'application/json'}
            });

            if (resp.ok) {
                const data = await resp.json();

                if (data.totalCount > 0) {
                    setProducts(data.items);
                    setPageNo(data.page)
                }
                //console.log(data);
            } else {
                console.log("No products were found");
            }
        } catch {
            console.log("Error. Could not get product list");
        }
    }

    console.log(products);

    const listData = products ? products.map((r, id) => (
        <div>
            <ProductItem product={r}/>
            <p key={r.id}>Name: {r.name} | Vendor: {r.vendor} | Price: {r.price}</p>
            <ul>
                {r.categories.map(c => (
                    <li key={c.id}>
                        {c.name}
                    </li>
                ))}
            </ul>
        </div>
    )) : <p>No data</p>;

    return(
        <div>
            {listData}
        </div>
    )
}