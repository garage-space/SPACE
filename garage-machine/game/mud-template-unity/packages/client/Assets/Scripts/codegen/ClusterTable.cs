/* Autogenerated file. Manual edits will not be saved.*/

#nullable enable
using System;
using mud.Client;
using mud.Network.schemas;
using mud.Unity;
using UniRx;
using Property = System.Collections.Generic.Dictionary<string, object>;

namespace DefaultNamespace
{
    public class ClusterTableUpdate : TypedRecordUpdate<Tuple<ClusterTable?, ClusterTable?>> { }

    public class ClusterTable : IMudTable
    {
        public static readonly TableId TableId = new("", "Cluster");

        public ulong? id;

        public static ClusterTable? GetTableValue(string key)
        {
            var query = new Query()
                .Find("?value", "?attribute")
                .Where(TableId.ToString(), key, "?attribute", "?value");
            var result = NetworkManager.Instance.ds.Query(query);
            var clusterTable = new ClusterTable();
            var hasValues = false;

            foreach (var record in result)
            {
                var attribute = record["attribute"].ToString();
                var value = record["value"];

                switch (attribute)
                {
                    case "id":
                        var idValue = (ulong)value;
                        clusterTable.id = idValue;
                        hasValues = true;
                        break;
                }
            }

            return hasValues ? clusterTable : null;
        }

        public static IObservable<ClusterTableUpdate> OnRecordUpdate()
        {
            return NetworkManager.Instance.ds.OnDataStoreUpdate
                .Where(
                    update =>
                        update.TableId == TableId.ToString() && update.Type == UpdateType.SetField
                )
                .Select(
                    update =>
                        new ClusterTableUpdate
                        {
                            TableId = update.TableId,
                            Key = update.Key,
                            Value = update.Value,
                            TypedValue = MapUpdates(update.Value)
                        }
                );
        }

        public static IObservable<ClusterTableUpdate> OnRecordInsert()
        {
            return NetworkManager.Instance.ds.OnDataStoreUpdate
                .Where(
                    update =>
                        update.TableId == TableId.ToString() && update.Type == UpdateType.SetRecord
                )
                .Select(
                    update =>
                        new ClusterTableUpdate
                        {
                            TableId = update.TableId,
                            Key = update.Key,
                            Value = update.Value,
                            TypedValue = MapUpdates(update.Value)
                        }
                );
        }

        public static IObservable<ClusterTableUpdate> OnRecordDelete()
        {
            return NetworkManager.Instance.ds.OnDataStoreUpdate
                .Where(
                    update =>
                        update.TableId == TableId.ToString()
                        && update.Type == UpdateType.DeleteRecord
                )
                .Select(
                    update =>
                        new ClusterTableUpdate
                        {
                            TableId = update.TableId,
                            Key = update.Key,
                            Value = update.Value,
                            TypedValue = MapUpdates(update.Value)
                        }
                );
        }

        public static Tuple<ClusterTable?, ClusterTable?> MapUpdates(
            Tuple<Property?, Property?> value
        )
        {
            ClusterTable? current = null;
            ClusterTable? previous = null;

            if (value.Item1 != null)
            {
                try
                {
                    current = new ClusterTable
                    {
                        id = value.Item1.TryGetValue("id", out var idVal) ? (ulong)idVal : default,
                    };
                }
                catch (InvalidCastException)
                {
                    current = new ClusterTable { id = null, };
                }
            }

            if (value.Item2 != null)
            {
                try
                {
                    previous = new ClusterTable
                    {
                        id = value.Item2.TryGetValue("id", out var idVal) ? (ulong)idVal : default,
                    };
                }
                catch (InvalidCastException)
                {
                    previous = new ClusterTable { id = null, };
                }
            }

            return new Tuple<ClusterTable?, ClusterTable?>(current, previous);
        }
    }
}
