import AssetList, { AssetRowData } from "./assetList";
import { FormEvent, useEffect, useState } from "react";
import {
  AssetState,
  FilterAssetRequest,
  FilterAssetResponse,
  OrderByFieldName,
} from "../../app/models/asset/Asset";
import agent from "../../app/api/agent";
import { Order } from "../../app/components/table/sortTable";
import { Stack } from "@mui/material";
import { Search } from "@mui/icons-material";
import AppButton from "../../app/components/buttons/Button";
import AppSearchInput from "../../app/components/AppSearchInput";
import {
  SetURLSearchParams,
  useLocation,
  useNavigate,
  useSearchParams,
} from "react-router-dom";
import AppPagination from "../../app/components/paginationButtons/paginationButtons";
import AssetStateFilter from "./assetStateFilter";
import CategoryFilter from "./categoryFilter";
import SelectedItem from "../../app/models/SelectedItem";
import { Category } from "../../app/models/category/Category";
import AssetInfo from "../../app/components/assetInfo/assetInfo";
import ConfirmModal from "../../app/components/confirmModal";
import NotifyModal from "../../app/components/notifyModal";

function setFilterSearchParam(
  query: FilterAssetRequest,
  setSearchParams: SetURLSearchParams
) {
  const params = new URLSearchParams();

  if (query?.search) {
    params.set("search", query.search.toString());
  }

  if (query?.states && query.states.length > 0) {
    const normalizeState: string[] = query.states.map(
      (item) => AssetState[item] ?? item
    );
    normalizeState.forEach((state) => {
      if (state) params.append("states", state);
    });
  }

  if (query?.categories && query.categories.length > 0) {
    query?.categories?.forEach((category) => {
      if (category) params.append("categories", category);
    });
  }

  if (query?.orderBy) {
    params.set("orderBy", query.orderBy.toString());
  }

  if (query?.order) {
    params.set("order", query.order.toString());
  }

  if (query?.pageNumber) {
    params.set("pageNumber", query.pageNumber.toString());
  }

  if (query?.pageSize) {
    params.set("pageSize", query.pageSize.toString());
  }

  setSearchParams(params);
}

export default function ManagementAssetPage() {
  const [searchParams, setSearchParams] = useSearchParams();
  const navigate = useNavigate();
  const location = useLocation();
  let { passedOrder, passedOrderBy, currentStates } = location.state || {};
  const currentStatesPassed = currentStates as FilterAssetRequest;
  const initSearch =
    currentStatesPassed?.search ?? searchParams.get("search") ?? "";
  const initPageNumber = Number(searchParams.get("pageNumber") ?? "1");
  const initPageSize = Number(searchParams.get("pageSize") ?? "5");

  const initStates = currentStatesPassed?.states
    ? currentStatesPassed?.states?.map((state) => AssetState[state])
    : searchParams.getAll("states")?.length === 0
    ? [
        AssetState[AssetState.Assigned],
        AssetState[AssetState.Available],
        AssetState[AssetState["Not available"]],
      ]
    : searchParams.getAll("states");

  const initCategories =
    currentStatesPassed?.categories ?? searchParams.getAll("categories");
  const initOrder =
    passedOrder ?? (searchParams.get("order") as Order) ?? "asc";
  const initOrderBy =
    passedOrderBy ??
    (searchParams.get("orderBy") as OrderByFieldName) ??
    "name";

  //Details
  const [clickOnAsset, setClickOnAsset] = useState<boolean>(false);
  const [assetId, setAssetId] = useState<string>("0");

  const [states, setStates] = useState<string[]>(initStates);

  const [categories, setCategories] = useState<string[]>(initCategories);

  const [query, setQuery] = useState<FilterAssetRequest>(
    currentStatesPassed ?? {
      search: initSearch,
      states:
        initStates
          ?.map((state) => AssetState[state as keyof typeof AssetState])
          ?.filter(
            (mappedState) => mappedState !== undefined && mappedState !== null
          ) ?? [],
      categories: initCategories,
      pageNumber: initPageNumber > 0 ? initPageNumber : 1,
      pageSize: initPageSize > 0 ? initPageSize : 5,
      order: initOrder,
      orderBy: initOrderBy,
    }
  );

  const [searchInput, setSearchInput] = useState<string>(initSearch);

  const { data, isLoading, error, mutate } = agent.Asset.filter(query);
  const {
    data: categoryData,
    isLoading: categoryLoading,
    error: categoryError,
  } = agent.Category.all();

  //delete asset
  const [isDeletingModalOpen, setIsDeletingModalOpen] = useState(false);
  const [currentDeletingId, setCurrentDeletingId] = useState("");

  const [isOepningNotifyModal, setIsOepningNotifyModal] = useState(false);

  const handleDelete = async (id: string) => {
    try {
      await agent.Asset.delete(id).then(mutate);
    } catch (error: any) {
      if (
        error.message ===
        `Can't delete asset which belongs to one or more historical assignments`
      ) {
        setIsOepningNotifyModal(true);
        console.log(error);
      }
    }
  };

  useEffect(() => {
    if (!isLoading) {
      window.history.replaceState({}, "");
    }
  }, [isLoading]);

  const setOrderBy = (orderBy: OrderByFieldName) => {
    const newQuery = { ...query, orderBy: orderBy };
    setQuery((pre) => ({ ...pre, orderBy: orderBy }));
    setFilterSearchParam(newQuery, setSearchParams);
  };

  const setOrder = (order: Order) => {
    const newQuery = { ...query, order: order };
    setQuery((pre) => ({ ...pre, order: order }));
    setFilterSearchParam(newQuery, setSearchParams);
  };

  const handleClickOnAsset = (rowId: string) => {
    setClickOnAsset(true);
    setAssetId(data.items.result[rowId].id);
  };

  const handlePageNumberChange = (value: any) => {
    let pageNumber = Number(value);
    pageNumber = !pageNumber || pageNumber <= 0 ? 1 : pageNumber;
    const newQuery: FilterAssetRequest = { ...query, pageNumber };
    setQuery(newQuery);
    setFilterSearchParam(newQuery, setSearchParams);
  };

  const handleSearchInputChange = (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    const { name, value } = event.target;
    setSearchInput(value);
  };

  const handleSearchSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const newQuery: FilterAssetRequest = {
      ...query,
      pageNumber: 1,
      search: searchInput?.trim(),
    };
    setQuery(newQuery);
    setFilterSearchParam(newQuery, setSearchParams);
  };

  const handleStateFilterClick = () => {
    let newQuery: FilterAssetRequest;
    if (states.length === 0 || states.includes("all")) {
      newQuery = { ...query, states: [], pageNumber: 1 };
      setQuery(newQuery);
      setFilterSearchParam(newQuery, setSearchParams);
    } else {
      newQuery = {
        ...query,
        states: states
          .map((state) => AssetState[state as keyof typeof AssetState])
          .filter(
            (mappedState) => mappedState !== undefined && mappedState !== null
          ),
        pageNumber: 1,
      };
      setQuery(newQuery);
      setFilterSearchParam(newQuery, setSearchParams);
    }
  };

  const handleCategoryFilterClick = () => {
    let newQuery: FilterAssetRequest;
    if (categories.length === 0 || categories.includes("all")) {
      newQuery = { ...query, categories: [], pageNumber: 1 };
      setQuery(newQuery);
      setFilterSearchParam(newQuery, setSearchParams);
    } else {
      newQuery = { ...query, categories: categories, pageNumber: 1 };
      setQuery(newQuery);
      setFilterSearchParam(newQuery, setSearchParams);
    }
  };

  return (
    <div className="flex justify-center h-full">
      <div className="container">
        <p className="text-primary text-xl font-bold justify-start items-start">
          Asset List
        </p>
        <Stack
          direction="row"
          justifyContent="space-between"
          alignItems="center"
          spacing={12}
          className="mt-3"
        >
          <Stack
            direction="row"
            justifyContent="flex-start"
            alignItems="center"
            spacing={12}
          >
            <AssetStateFilter
              states={states}
              setStates={setStates}
              onSubmit={handleStateFilterClick}
            />
            <CategoryFilter
              items={
                (categoryData?.items?.result?.map((item: Category) => ({
                  id: item.name ?? "",
                  name: item.name ?? "",
                })) as SelectedItem[]) ?? []
              }
              categories={categories}
              setcategories={setCategories}
              onSubmit={handleCategoryFilterClick}
            />
          </Stack>
          <Stack
            direction="row"
            justifyContent="flex-end"
            alignItems="center"
            spacing={4}
          >
            <form onSubmit={handleSearchSubmit}>
              <Stack
                direction="row"
                justifyContent="flex-start"
                alignItems="center"
                spacing={2}
              >
                <AppSearchInput
                  type="text"
                  placeholder="Search"
                  name="name"
                  value={searchInput}
                  onChange={handleSearchInputChange}
                  className="!rounded-l-md !border !border-gray-400 !border-r-0"
                />

                <button
                  type="submit"
                  className="border border-gray-500 border-l-0 rounded-r-md mx-0 hover:cursor-pointer"
                  style={{ margin: 0, padding: "6px", height: "40px" }}
                >
                  <Search className="mx-0" />
                </button>
              </Stack>
            </form>
            <AppButton
              content="Create new asset"
              className="py-[6px] min-w-40"
              onClickOn={() => {
                navigate(`/manage-asset/create-asset`);
              }}
            />
          </Stack>
        </Stack>
        <div className="mt-3">
          <AssetList
            data={
              data?.items?.result?.map((item: FilterAssetResponse) => ({
                id: item.id,
                assetCode: item.assetCode,
                name: item.name,
                category: item.category,
                state:
                  item.state !== undefined ? AssetState[item.state] : undefined,
                action: {
                  id: item.id,
                  state:
                    item.state !== undefined
                      ? AssetState[item.state]
                      : undefined,
                  category: item.category,
                  name: item.name,
                  specification: item.specification,
                  installedDate: item.installedDate,
                },
              })) as AssetRowData[]
            }
            error={error}
            isLoading={isLoading}
            order={query?.order ?? "asc"}
            setOrder={setOrder}
            orderBy={query?.orderBy}
            setOrderBy={setOrderBy}
            setCurrentDeletingId={setCurrentDeletingId}
            setIsOpenDeletingModal={setIsDeletingModalOpen}
            handleClick={(event, rowId) => handleClickOnAsset(rowId)}
            currentStates={query}
          />

          <Stack
            direction="row"
            justifyContent="flex-end"
            alignItems="baseline"
          >
            <AppPagination
              totalPage={data?.metaData?.totalPageCount ?? 1}
              onChange={handlePageNumberChange}
              currentPage={data?.metaData?.currentPage ?? 1}
            />
          </Stack>
        </div>
      </div>
      <ConfirmModal
        message="Do you want to delete this asset?"
        confirmMessage="Delete"
        isOpen={isDeletingModalOpen}
        onClose={() => setIsDeletingModalOpen(false)}
        onConfirm={() => {
          setIsDeletingModalOpen(false);
          handleDelete(currentDeletingId);
        }}
      />

      <NotifyModal
        title="Cannot Delete Asset"
        message="Delete failed"
        isOpen={isOepningNotifyModal}
        onClose={() => setIsOepningNotifyModal(false)}
      />
      {clickOnAsset && (
        <AssetInfo
          assetId={assetId}
          onClose={() => {
            setClickOnAsset(false);
          }}
        />
      )}
    </div>
  );
}
