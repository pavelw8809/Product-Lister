export interface Category {
    id: string;
    name: string;
    color: string;
}

export interface Product {
    id: string;
    name: string;
    vendor: string;
    price: number;
    categories: Category[];
}