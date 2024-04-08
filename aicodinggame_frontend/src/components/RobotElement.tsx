import React, {Component, JSX, ReactNode} from "react";
import './styles/RobotElement.css'
import UnfoldingElement from "./UnfoldingElement";
import StatisticElement, {IStatistic} from "./StatisticElement"
import BattleElement, {IBattle} from "./BattleElement"

interface IRobot {
    name: string
    statistic: IStatistic
    battles: [IBattle?]
}

function RobotElement(props: IRobot) {
    
    return (
        <UnfoldingElement id={"rootContainer"} header={`Имя робота: ${props.name}`}>
            <>
                <UnfoldingElement header={"Cтатистика"}>
                    <StatisticElement props={ props.statistic }></StatisticElement>
                </UnfoldingElement>
                
                <UnfoldingElement header={"Бои"}>{ 
                    props.battles.length > 0 ? 
                        props.battles.map((battle) =>
                            <BattleElement props={battle!}></BattleElement>
                        ) : null
                }</UnfoldingElement>
            </>
        </UnfoldingElement>
    )
}

export default RobotElement;