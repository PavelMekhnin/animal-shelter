import React, { Dispatch, useEffect } from "react";
import { AppState } from "../reducers/rootReducer";
import { ShelterCardPreview } from "./ShelterCardPreview";
import { connect, useDispatch } from "react-redux";
import { fetchShelters } from "../actions/shelterActions";
import { bindActionCreators, AnyAction } from "redux";

const ShelterList: React.FC<Props> = ({ shelters, fetch, loading }) => {
    fetch()

    return (
        <div className="container">
            <div className="row">
                <input type="search" name="" id="search" placeholder="Поиск..." />
            </div>
            {
                loading  == false ? (
                    <div className="row">
                        {
                            shelters.length == 0 ? (
                                <h1>Ничег оне найдено :(</h1>
                            )
                                :
                                (
                                    shelters.map(x => {
                                        return (
                                            <ShelterCardPreview card={x} key={x.id}></ShelterCardPreview>
                                        )
                                    })
                                )

                        }
                    </div>
                ) : (
                        <div className="container">
                            <div className="progress">
                                <div className="indeterminate"></div>
                            </div>
                        </div>
                    )
            }
        </div>
    )
}

const mapStateToProps = (state: AppState) => {
    return {
        shelters: state.shelters.shelters,
        loading: false
    }
}

const mapDispatchToProps = (dispatch: Dispatch<any>) => ({
    fetch: () => {
        dispatch(fetchShelters());
    }
})


type Props = ReturnType<typeof mapStateToProps> & ReturnType<typeof mapDispatchToProps>;

export default connect(mapStateToProps, mapDispatchToProps)(ShelterList);