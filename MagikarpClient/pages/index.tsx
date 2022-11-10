import {
  createColumnHelper,
  flexRender,
  getCoreRowModel,
  getSortedRowModel,
  SortingState,
  useReactTable,
} from '@tanstack/react-table';
import React from 'react';
import PrimaryLayout from '../layouts/PrimaryLayout';
import { NextPageWithLayout } from './page';

type KarpTransaction = {
  id: number;
  weight: number;
  fishCount: number;
  createdAt: Date;
};

const Home: NextPageWithLayout = () => {
  const [data, setData] = React.useState<KarpTransaction[]>([]);
  const [weight, setWeight] = React.useState<number>(0);
  const [fishCount, setFishCount] = React.useState<number>(1);
  const [evolution, setEvolution] = React.useState<boolean>(false);

  const url = 'https://localhost:7037';
  React.useEffect(() => {
    fetch(`${url}/karpTransactions`)
      .then((response) => response.json())
      .then((responseJson) => {
        console.log(responseJson);
        setData(responseJson.karpTransactions);
      })
      .catch((err) => {
        console.log(err.message);
      });
  }, []);

  const columnHelper = createColumnHelper<KarpTransaction>();

  const columns = [
    columnHelper.accessor((row) => row.id, {
      id: `id`,
      cell: (info) => info.getValue(),
      header: () => <span>Id</span>,
      footer: (info) => info.column.id,
    }),
    columnHelper.accessor((row) => row.weight, {
      id: 'weight',
      cell: (info) => <span>{`${info.getValue().toFixed(2)} kg`}</span>,
      header: () => <span>Waga</span>,
      footer: (info) => info.column.id,
    }),
    columnHelper.accessor((row) => row.fishCount, {
      id: 'fishCount',
      cell: (info) => info.getValue(),
      header: () => <span>Liczba Sztuk</span>,
      footer: (info) => info.column.id,
    }),
    columnHelper.accessor((row) => row.createdAt, {
      id: 'createdAt',
      cell: (info) => new Date(info.getValue()).toLocaleString(),
      header: () => <span>Data Sprzedaży</span>,
      footer: (info) => info.column.id,
    }),
    columnHelper.accessor((row) => row.id, {
      id: 'deleteAction',
      cell: (info) => (
        <button
          onClick={() => {
            const requestOptions = {
              method: 'DELETE',
            };

            fetch(`${url}/karpTransaction/${info.getValue()}`, requestOptions)
              .then(() =>
                setData(data.filter((row) => row.id != info.getValue()))
              )
              .catch((err) => {
                console.log(err.message);
              });
          }}
        >
          DELETE
        </button>
      ),
      header: () => '',
    }),
  ];

  const [sorting, setSorting] = React.useState<SortingState>([
    {
      id: 'createdAt',
      desc: true,
    },
  ]);

  const table = useReactTable({
    data,
    columns,
    state: {
      sorting,
    },
    onSortingChange: setSorting,
    getCoreRowModel: getCoreRowModel(),
    getSortedRowModel: getSortedRowModel(),
  });

  return (
    <div className="container">
      <div className="welcome">
        <h1 className="title">Welcome to Magikarp!</h1>
        {evolution ? (
          <img src="/evolution.gif" alt="Evolution" height={285} />
        ) : (
          <img src="/magikarp.svg" alt="Magikarp" />
        )}
      </div>
      <form
        className="m20"
        onSubmit={(event) => {
          event.preventDefault();

          const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
              weight: weight,
              fishCount: fishCount,
            }),
          };

          fetch(`${url}/karpTransaction`, requestOptions)
            .then((response) => response.json())
            .then((responseJson) => setData([...data, responseJson]))
            .then(() => {
              if (weight / fishCount >= 3) {
                setEvolution(true);
                setTimeout(() => setEvolution(false), 6000);
              }
            })
            .catch((err) => {
              console.log(err.message);
            });
        }}
      >
        <label>
          Waga:
          <input
            type="number"
            step={0.01}
            value={weight}
            onChange={(e) => setWeight(e.target.valueAsNumber)}
          />
        </label>

        <label>
          Ilość Sztuk:
          <input
            type="number"
            step={1}
            value={fishCount}
            min={1}
            onChange={(e) => setFishCount(e.target.valueAsNumber)}
          />
        </label>
        <input type="submit" value="Dodaj" />
      </form>
      <div>
        <table>
          <thead>
            {table.getHeaderGroups().map((headerGroup) => (
              <tr key={headerGroup.id}>
                {headerGroup.headers.map((header) => (
                  <th key={header.id} colSpan={header.colSpan}>
                    {header.isPlaceholder ? null : (
                      <div
                        {...{
                          className: header.column.getCanSort()
                            ? 'cursor-pointer select-none'
                            : '',
                          onClick: header.column.getToggleSortingHandler(),
                        }}
                      >
                        {flexRender(
                          header.column.columnDef.header,
                          header.getContext()
                        )}
                        {{
                          asc: ' 🔼',
                          desc: ' 🔽',
                        }[header.column.getIsSorted() as string] ?? null}
                      </div>
                    )}
                  </th>
                ))}
              </tr>
            ))}
          </thead>
          <tbody>
            {table.getRowModel().rows.map((row) => (
              <tr key={row.id}>
                {row.getVisibleCells().map((cell) => (
                  <td key={cell.id}>
                    {flexRender(cell.column.columnDef.cell, cell.getContext())}
                  </td>
                ))}
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default Home;

Home.getLayout = (page) => {
  return <PrimaryLayout>{page}</PrimaryLayout>;
};
