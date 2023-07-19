export interface IPagination {
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
