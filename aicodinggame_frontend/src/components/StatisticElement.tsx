import React from "react";

export interface IStatistic{
    winPercent?: number;
    totalKillsCount?: number;
    accuracy?: number;
}

export default function StatisticElement({props}: {props: IStatistic}){
    return (
        <>
            <table>
                <tr>
                    <td>Количество убийств: {props.totalKillsCount ? props.totalKillsCount : 0}</td>
                </tr>
                <tr>
                    <td>Точность: {props.accuracy ? `${props.accuracy * 100}%` : "0%"}</td>
                </tr>
                <tr>
                    <td>Процент побед: {props.winPercent ? `${props.winPercent * 100}%` : "0%"} </td>
                </tr>
            </table>
        </>
    )
}