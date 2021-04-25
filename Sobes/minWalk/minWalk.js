// /****************************************************************
// Описание
// 	Вам дается квадратная сетка с обычными `.` и заблокированными `X` ячейками.
//   Ваша игровая фигура может перемещаться по любой строке или столбцу или диагонали,
//   пока не достигнет края сетки или заблокированной ячейки.
//   Учитывая сетку, начальную и конечную позиции, определите количество ходов,
//   чтобы добраться до конечной позиции.

// Например
// 	Дана сетка:
//   .X.
//   .X.
//   ...

//   Система координаты для данной сетки:
//   0.0   0.1   0.2
//   1.0   1.1   1.2
//   2.0   2.1   2.2

//   Начальна позиция 2.1 (отсчет идет с верхнего левого края сетки 0.0)
//   Конечная позиция 0.2

//   Путь движения между точками: (2.1) -> (1.2) -> (0.2)
//   Ответ: необходимо выполнить 2 шага.

// 	Задача
//   	Завершите выполнение функции в редакторе. Функция должена вывести целое число,
//     обозначающее минимальное количество шагов для перехода от начальной позиции к конечной.

//   Ограничения
//   	Длина сетки > 1 и < 100
//     Координата начальной и конечной точки входит в предоставленную сетку.

// ****************************************************************/

//

//

// Алгоритм Дейкстры нахождения кратчайшего пути

function minWalk(gridList, startX, startY, endX, endY) {
    console.log(gridList);

    let flatString = gridList.reduce((acc, cur) => acc + cur, "");

    let step = gridList.length;
    let size = gridList.length ** 2;
    let beginIndex = startX * step + startY;
    let temp = 0;
    let minindex, min;

    let set = new Set(Array.from(Array(size), () => temp++));

    // let distance = Array(flatString.length); // минимальное расстояние
    let distance = []; // минимальное расстояние
    let visited = []; // посещенные вершины

    let linksArr = Array.from(Array(size), () => Array.from(Array(size), () => 0)); // матрица связей

    // заполнение матрицы связей. Все веса дуг графа равны между собой - один шаг
    // дуги имеются только в пределах квадрата 3*3 вокруг любого выбраного узла графа
    for (let n = 0; n < size; n++) {
        let i0 = Math.floor(n / step);
        let j0 = n % step;
        // i0 j0 - координаты ячейки в массиве gridList, соответствующей номеру строки матрицы связей

        for (let k = n; k < size; k++) {
            let i_k = Math.floor(k / step);
            let j_k = k % step;

            // проверяем, чтобы координаты "k-атого" графа были внутри квадрата вокруг (i0,j0)
            if (i0 - 1 <= i_k && i_k <= i0 + 1 && j0 - 1 <= j_k && j_k <= j0 + 1) {
                linksArr[n][k] = linksArr[k][n] = flatString[n] !== "." || flatString[k] !== "." ? 0 : 1;
            }
        }
    }

    console.log("linksArr ", linksArr);

    // Инициализация
    for (let i = 0; i < size; i++) {
        distance[i] = size + 1; // такое число будет говорить о невозможности попасть в этот узел (вершину графа)
        visited[i] = 1; // 1 - вершина еще не просчитана, 0 - подсчитывать уже не надо, вершину прошли
    }

    distance[beginIndex] = 0;

    do {
        minindex = size + 1;
        min = size + 1;

        for (let i = 0; i < size; i++) {
            // Если вершину ещё не прошли и вес меньше min
            if (visited[i] && distance[i] < min) {
                min = distance[i];
                minindex = i;
            }
        }

        if (minindex !== size + 1) {
            for (let i = 0; i < size; i++) {
                if (linksArr[minindex][i] > 0) {
                    temp = min + linksArr[minindex][i];
                    if (temp < distance[i]) {
                        distance[i] = temp;
                    }
                }
            }
            visited[minindex] = 0;
        }
        //
    } while (minindex < size + 1);

    // массив кратчайших расстояний от стартовой точки
    console.log("distance ", distance);

    // построение пути от конечной точки до начальной с учетом кратчайших расстояний
    let endIndex = endX * step + endY;

    visited = []; // посещенные узлы
    visited[0] = endIndex; // начальный элемент для восстанеовления обратного пути
    let k = 1; // индекс предыдущего узла в массиве результата visited
    let weight = distance[endIndex]; // вес конечной вершины
    let previousWeight;

    while (endIndex !== beginIndex && previousWeight !== weight) {
        previousWeight = weight;
        // просматриваем все вершины
        for (let i = 0; i < size; i++) {
            // если дуга есть
            if (linksArr[i][endIndex] !== 0) {
                temp = weight - linksArr[i][endIndex]; // вес пути из предыдущей вершины
                if (temp === distance[i]) {
                    // если вес совпал с рассчитанным
                    // значит из этого узла графа и был переход
                    weight = temp; // новый вес
                    endIndex = i; // сохраняем предыдущую вершину
                    visited[k++] = i;
                }
            }
        }
    }

    let result = "Решений нет.";

    if (endIndex === beginIndex) {
        result = visited.reverse().map((el) => `(${Math.floor(el / step)},${el % step})`);
        result = result.join(" => ");
        result = `Ответ: необходимо выполнить ${visited.length - 1} шага(шагов)\n${result}`;
    }

    console.log("visited ", visited);

    return result;
}

const result = minWalk([".X.", ".X.", "..."], 2, 1, 0, 2);

$("#res").text(result);

//
//
// другой (первоначальный) вариант заполнения  матрицы связей, но более трудоемкий
// Все веса дуг графа равны между собой - один шаг
// дуги имеются только в пределах квадрата 3*3 вокруг любого выбраного узла графа

// for (let n = 0; n < size; n++) {
//     let i0 = Math.floor(n / step);
//     let j0 = n % step;
//     // i0 j0 - координаты ячейки в массиве gridList, соответствующей номеру строки матрицы связей

//     // дальше перебираем массив gridList и на каждом элементе [i0,j0] обходим всех его соседей

//     for (let i = i0 - 1; i <= i0 + 1; ++i) {
//         for (let j = j0 - 1; j <= j0 + 1; ++j) {
//             // проверка на выход за границы массива gridList
//             // и проверка на то, что обрабатываемая ячейка не равна изначальной ячейке
//             if (0 <= i && i < step && 0 <= j && j < step && (i != i0 || j != j0)) {
//                 linksArr[n][i * step + j] = flatString[n] !== "." || flatString[i * step + j] !== "." ? 0 : 1;
//             }
//         }
//     }
// }
//

//
//
//
