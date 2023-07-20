export interface IProductsSettings {
  simulators: string;
  sortableFields: ISortableField[];
  order: string;
  skip: number;
  take: number;
}

export interface ISortableField {
  field: string;
  display: string;
  isSortField: boolean;
}
